using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using CreatorElements;
using System.Reflection;
using System.Runtime.InteropServices;
using WinForm = System.Windows.Forms;
using System.Collections.Generic;

namespace Command
{
    public class CommandClass
    {
        public static int MaxEdge = 1300;
        public static int woodCover { get; set; }
        public static int woodFrame { get; set; }
        public static int CountCover { get; set; }

        double length, width, height;

        [CommandMethod("WoodBox")]
        public void RunCommand()
        {
            // link to the active document, database and document editor
            Document adoc = Application.DocumentManager.MdiActiveDocument;
            if (adoc == null)
                return;
            Database db = adoc.Database;
            Editor ed = adoc.Editor;

            // link to the object from the drawing
            ObjectId entId;
            PromptEntityResult entRes = ed.GetEntity("\nSelect an object: ");
            if (entRes.Status != PromptStatus.OK)
                return;
            entId = entRes.ObjectId;

            // checking the object
            bool isCorrect = entId.IsValid
                          && !entId.IsErased
                          && !entId.IsEffectivelyErased
                          && entId.ObjectClass.Name.Equals("AcDb3dSolid");

            if (!isCorrect)
            {             
                ed.WriteMessage("\nInvalid  object!");
                return;
            }

            // starting transaction
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {

                // starting form
                FormWoodMaterial form = new FormWoodMaterial();
                WinForm.DialogResult dialRes = Application.ShowModalDialog(form);
                if (dialRes != WinForm.DialogResult.OK)
                    return;

                // get the object and transform it into "solid"
                Solid3d solid = tr.GetObject(entId, OpenMode.ForWrite) as Solid3d;

                // get the center of mass
                Point3d solidCentroid = new Point3d(solid.MassProperties.Centroid.X,
                                                    solid.MassProperties.Centroid.Y,
                                                    solid.MassProperties.Centroid.Z);

                // GetBoundingBox
                object acObject = solid.AcadObject;
                object[] arrPoint = new object[2];
                arrPoint[0] = new VariantWrapper(0);
                arrPoint[1] = new VariantWrapper(0);
                ParameterModifier param = new ParameterModifier(2);
                param[0] = true;
                param[1] = true;

                ParameterModifier[] modifiersParam = new ParameterModifier[] { param };
                acObject.GetType().InvokeMember("GetBoundingBox", BindingFlags.InvokeMethod, null, acObject, arrPoint,
                                                 modifiersParam, null, null);
                Point3d minPoint = new Point3d((double[])arrPoint[0]);
                Point3d maxPoint = new Point3d((double[])arrPoint[1]);

                // sizes
                length = maxPoint[0] - minPoint[0];
                width = maxPoint[1] - minPoint[1];
                height = maxPoint[2] - minPoint[2];

                if (length < (2 * woodCover + 30) || width < (2 * woodCover + 30) || height < (2 * woodCover + 30))
                {
                    ed.WriteMessage("\nInvalid  object, increase sizes");
                    return;
                }

                // link to the object "drawing space"
                ObjectId mspaceId = SymbolUtilityServices.GetBlockModelSpaceId(db);
                BlockTableRecord mspace = tr.GetObject(mspaceId, OpenMode.ForWrite) as BlockTableRecord;

                double minEdge = CreatorWoodElements.MinEdge(length, width, height);

                // create solid frame
                List<Solid3d> listWoodFrame = new List<Solid3d>();
                listWoodFrame = CreatorWoodElements.CreateWoodFrame(length, width, height, minEdge,
                                                                    solidCentroid, woodCover, woodFrame, CountCover);
                // adding to the "drawing space"
                foreach (var item in listWoodFrame)
                {
                    mspace.AppendEntity(item);
                    tr.AddNewlyCreatedDBObject(item, true);
                }

                // create cover and add it to the "drawing space"
                if (CountCover == 1)
                {
                    Solid3d newSolidUp = CreatorWoodElements.CreateWoodCover(length, width, height, minEdge,
                                                                             solidCentroid, woodCover, true);
                    mspace.AppendEntity(newSolidUp);
                    tr.AddNewlyCreatedDBObject(newSolidUp, true);
                }
                else if (CountCover == 2)
                {
                    Solid3d newSolidUp = CreatorWoodElements.CreateWoodCover(length, width, height, minEdge,
                                                                             solidCentroid, woodCover, true);
                    mspace.AppendEntity(newSolidUp);
                    tr.AddNewlyCreatedDBObject(newSolidUp, true);
                    Solid3d newSolidDown = CreatorWoodElements.CreateWoodCover(length, width, height, minEdge,
                                                                               solidCentroid, woodCover, false);
                    mspace.AppendEntity(newSolidDown);
                    tr.AddNewlyCreatedDBObject(newSolidDown, true);
                }

                // delete old "solid"
                solid.Erase(true);

                tr.Commit();
            }
        }
    }
}
