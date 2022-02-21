using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Command;
using System;
using System.Collections.Generic;

namespace CreatorElements
{
    public class CreatorWoodElements
    {
        public static Solid3d CreateWoodCover(double length, double width, double height, double minEdge,
                                              Point3d solidCentroid, int woodCover, bool sign)
        {
            int flag = 1;
            if (!sign)
                flag = -1;

            Point3d newSolidCentroid;
            Solid3d resultSolid = new Solid3d();

            if (minEdge == height)
            {
                newSolidCentroid = new Point3d(solidCentroid.X,
                                               solidCentroid.Y,
                                               solidCentroid.Z + flag * (height - woodCover) / 2);
                resultSolid.SetDatabaseDefaults();
                resultSolid.CreateBox(length, width, woodCover);
                resultSolid.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
            }
            else if (minEdge == length)
            {
                newSolidCentroid = new Point3d(solidCentroid.X + flag * (length - woodCover) / 2,
                                               solidCentroid.Y,
                                               solidCentroid.Z);
                resultSolid.SetDatabaseDefaults();
                resultSolid.CreateBox(woodCover, width, height);
                resultSolid.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
            }

            else
            {
                newSolidCentroid = new Point3d(solidCentroid.X,
                                               solidCentroid.Y + flag * (width - woodCover) / 2,
                                               solidCentroid.Z);
                resultSolid.SetDatabaseDefaults();
                resultSolid.CreateBox(length, woodCover, height);
                resultSolid.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
            }

            return resultSolid;
        }

        public static double MinEdge(double length, double width, double height)
        {
            return Math.Min(Math.Min(length, width), height);
        }

        public static List<Solid3d> CreateWoodFrame(double length, double width, double height, double minEdge,
                                              Point3d solidCentroid, int woodCover, int woodFrame, int CountCover)
        {
            List<Solid3d> wFrame = new List<Solid3d>();

            int flag = 0;
            if (CountCover == 1)
                flag = woodCover;
            else if (CountCover == 2)
                flag = 2 * woodCover;

            Point3d newSolidCentroid;
            Solid3d frameSolidRight = new Solid3d();
            Solid3d frameSolidLeft = new Solid3d();
            Solid3d frameSolidUp = new Solid3d();
            Solid3d frameSolidDown = new Solid3d();

            if (minEdge == length)
            {
                if (height >= width)
                {
                    newSolidCentroid = new Point3d(solidCentroid.X - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Y + (width - woodFrame) / 2,
                                                   solidCentroid.Z);
                    frameSolidUp.SetDatabaseDefaults();
                    frameSolidUp.CreateBox(minEdge - flag, woodFrame, height);
                    frameSolidUp.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidUp);

                    newSolidCentroid = new Point3d(solidCentroid.X - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Y - (width - woodFrame) / 2,
                                                   solidCentroid.Z );
                    frameSolidDown.SetDatabaseDefaults();
                    frameSolidDown.CreateBox(minEdge - flag, woodFrame, height);
                    frameSolidDown.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidDown);

                    newSolidCentroid = new Point3d(solidCentroid.X - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Y,
                                                   solidCentroid.Z + (height - woodFrame) / 2);
                    frameSolidRight.SetDatabaseDefaults();
                    frameSolidRight.CreateBox(minEdge - flag, width - 2 * woodFrame, woodFrame);
                    frameSolidRight.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidRight);

                    newSolidCentroid = new Point3d(solidCentroid.X - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Y,
                                                   solidCentroid.Z - (height - woodFrame) / 2);
                    frameSolidLeft.SetDatabaseDefaults();
                    frameSolidLeft.CreateBox(minEdge - flag, width - 2 * woodFrame, woodFrame);
                    frameSolidLeft.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidLeft);

                    if (height >= CommandClass.MaxEdge)
                    {
                        newSolidCentroid = new Point3d(solidCentroid.X - (CountCover == 1 ? (flag / 2) : 0),
                                                       solidCentroid.Y,
                                                       solidCentroid.Z);
                        Solid3d middleEdge = new Solid3d();
                        middleEdge.SetDatabaseDefaults();
                        middleEdge.CreateBox(minEdge - flag, width - 2 * woodFrame, woodFrame);
                        middleEdge.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                        wFrame.Add(middleEdge);
                    }

                }

                else
                {
                    newSolidCentroid = new Point3d(solidCentroid.X - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Y,
                                                   solidCentroid.Z + (height - woodFrame) / 2);
                    frameSolidUp.SetDatabaseDefaults();
                    frameSolidUp.CreateBox(minEdge - flag, width, woodFrame);
                    frameSolidUp.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidUp);

                    newSolidCentroid = new Point3d(solidCentroid.X - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Y,
                                                   solidCentroid.Z - (height - woodFrame) / 2);
                    frameSolidDown.SetDatabaseDefaults();
                    frameSolidDown.CreateBox(minEdge - flag, width, woodFrame);
                    frameSolidDown.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidDown);

                    newSolidCentroid = new Point3d(solidCentroid.X - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Y + (width - woodFrame) / 2,
                                                   solidCentroid.Z);
                    frameSolidRight.SetDatabaseDefaults();
                    frameSolidRight.CreateBox(minEdge - flag, woodFrame, height - 2 * woodFrame);
                    frameSolidRight.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidRight);

                    newSolidCentroid = new Point3d(solidCentroid.X - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Y - (width - woodFrame) / 2,
                                                   solidCentroid.Z);
                    frameSolidLeft.SetDatabaseDefaults();
                    frameSolidLeft.CreateBox(minEdge - flag, woodFrame, height - 2 * woodFrame);
                    frameSolidLeft.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidLeft);

                    if (width >= CommandClass.MaxEdge)
                    {
                        newSolidCentroid = new Point3d(solidCentroid.X - (CountCover == 1 ? (flag / 2) : 0),
                                                       solidCentroid.Y,
                                                       solidCentroid.Z);
                        Solid3d middleEdge = new Solid3d();
                        middleEdge.SetDatabaseDefaults();
                        middleEdge.CreateBox(minEdge - flag, woodFrame, height - 2 * woodFrame);
                        middleEdge.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                        wFrame.Add(middleEdge);
                    }
                }
            }

            if (minEdge == width)
            {
                if (length >= height)
                {
                    newSolidCentroid = new Point3d(solidCentroid.X,
                                                   solidCentroid.Y - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Z + (height - woodFrame) / 2);
                    frameSolidUp.SetDatabaseDefaults();
                    frameSolidUp.CreateBox(length, minEdge - flag, woodFrame);
                    frameSolidUp.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidUp);

                    newSolidCentroid = new Point3d(solidCentroid.X,
                                                   solidCentroid.Y - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Z - (height - woodFrame) / 2);
                    frameSolidDown.SetDatabaseDefaults();
                    frameSolidDown.CreateBox(length, minEdge - flag, woodFrame);
                    frameSolidDown.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidDown);

                    newSolidCentroid = new Point3d(solidCentroid.X + (length - woodFrame) / 2,
                                                   solidCentroid.Y - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Z);
                    frameSolidRight.SetDatabaseDefaults();
                    frameSolidRight.CreateBox(woodFrame, minEdge - flag, height - 2 * woodFrame);
                    frameSolidRight.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidRight);

                    newSolidCentroid = new Point3d(solidCentroid.X - (length - woodFrame) / 2,
                                                   solidCentroid.Y - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Z);
                    frameSolidLeft.SetDatabaseDefaults();
                    frameSolidLeft.CreateBox(woodFrame, minEdge - flag, height - 2 * woodFrame);
                    frameSolidLeft.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidLeft);

                    if (length >= CommandClass.MaxEdge)
                    {
                        newSolidCentroid = new Point3d(solidCentroid.X,
                                                       solidCentroid.Y - (CountCover == 1 ? (flag / 2) : 0),
                                                       solidCentroid.Z);
                        Solid3d middleEdge = new Solid3d();
                        middleEdge.SetDatabaseDefaults();
                        middleEdge.CreateBox(woodFrame, minEdge - flag, height - 2 * woodFrame);
                        middleEdge.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                        wFrame.Add(middleEdge);
                    }
                }

                else
                {
                    newSolidCentroid = new Point3d(solidCentroid.X + (length - woodFrame) / 2,
                                                   solidCentroid.Y - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Z);
                    frameSolidUp.SetDatabaseDefaults();
                    frameSolidUp.CreateBox(woodFrame, minEdge - flag, height);
                    frameSolidUp.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidUp);

                    newSolidCentroid = new Point3d(solidCentroid.X - (length - woodFrame) / 2,
                                                   solidCentroid.Y - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Z);
                    frameSolidDown.SetDatabaseDefaults();
                    frameSolidDown.CreateBox(woodFrame, minEdge - flag, height);
                    frameSolidDown.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidDown);

                    newSolidCentroid = new Point3d(solidCentroid.X,
                                                   solidCentroid.Y - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Z + (height - woodFrame) / 2);
                    frameSolidRight.SetDatabaseDefaults();
                    frameSolidRight.CreateBox(length - 2 * woodFrame, minEdge - flag, woodFrame);
                    frameSolidRight.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidRight);

                    newSolidCentroid = new Point3d(solidCentroid.X,
                                                   solidCentroid.Y - (CountCover == 1 ? (flag / 2) : 0),
                                                   solidCentroid.Z - (height - woodFrame) / 2);
                    frameSolidLeft.SetDatabaseDefaults();
                    frameSolidLeft.CreateBox(length - 2 * woodFrame, minEdge - flag, woodFrame);
                    frameSolidLeft.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidLeft);

                    if (height >= CommandClass.MaxEdge)
                    {
                        newSolidCentroid = new Point3d(solidCentroid.X,
                                                       solidCentroid.Y - (CountCover == 1 ? (flag / 2) : 0),
                                                       solidCentroid.Z);
                        Solid3d middleEdge = new Solid3d();
                        middleEdge.SetDatabaseDefaults();
                        middleEdge.CreateBox(length - 2 * woodFrame, minEdge - flag, woodFrame);
                        middleEdge.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                        wFrame.Add(middleEdge);
                    }
                }
            }

            if (minEdge == height)
            {
                if (length >= width)
                {
                    newSolidCentroid = new Point3d(solidCentroid.X,
                                                   solidCentroid.Y + (width - woodFrame) / 2,
                                                   solidCentroid.Z - (CountCover == 1 ? (flag / 2) : 0));
                    frameSolidUp.SetDatabaseDefaults();
                    frameSolidUp.CreateBox(length, woodFrame, minEdge - flag);
                    frameSolidUp.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidUp);

                    newSolidCentroid = new Point3d(solidCentroid.X,
                                                   solidCentroid.Y - (width - woodFrame) / 2,
                                                   solidCentroid.Z - (CountCover == 1 ? (flag / 2) : 0));
                    frameSolidDown.SetDatabaseDefaults();
                    frameSolidDown.CreateBox(length, woodFrame, minEdge - flag);
                    frameSolidDown.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidDown);

                    newSolidCentroid = new Point3d(solidCentroid.X + (length - woodFrame) / 2,
                                                   solidCentroid.Y,
                                                   solidCentroid.Z - (CountCover == 1 ? (flag / 2) : 0));
                    frameSolidRight.SetDatabaseDefaults();
                    frameSolidRight.CreateBox(woodFrame, width - 2 * woodFrame, minEdge - flag);
                    frameSolidRight.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidRight);

                    newSolidCentroid = new Point3d(solidCentroid.X - (length - woodFrame) / 2,
                               solidCentroid.Y,
                               solidCentroid.Z - (CountCover == 1 ? (flag / 2) : 0));
                    frameSolidLeft.SetDatabaseDefaults();
                    frameSolidLeft.CreateBox(woodFrame, width - 2 * woodFrame, minEdge - flag);
                    frameSolidLeft.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidLeft);

                    if (length >= CommandClass.MaxEdge)
                    {
                        newSolidCentroid = new Point3d(solidCentroid.X,
                                                       solidCentroid.Y,
                                                       solidCentroid.Z - (CountCover == 1 ? (flag / 2) : 0));
                        Solid3d middleEdge = new Solid3d();
                        middleEdge.SetDatabaseDefaults();
                        middleEdge.CreateBox(woodFrame, width - 2 * woodFrame, minEdge - flag);
                        middleEdge.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                        wFrame.Add(middleEdge);
                    }
                }

                else
                {
                    newSolidCentroid = new Point3d(solidCentroid.X + (length - woodFrame) / 2,
                                                   solidCentroid.Y,
                                                   solidCentroid.Z - (CountCover == 1 ? (flag / 2) : 0));
                    frameSolidUp.SetDatabaseDefaults();
                    frameSolidUp.CreateBox(woodFrame, width, minEdge - flag);
                    frameSolidUp.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidUp);

                    newSolidCentroid = new Point3d(solidCentroid.X - (length - woodFrame) / 2,
                                                   solidCentroid.Y,
                                                   solidCentroid.Z - (CountCover == 1 ? (flag / 2) : 0));
                    frameSolidDown.SetDatabaseDefaults();
                    frameSolidDown.CreateBox(woodFrame, width, minEdge - flag);
                    frameSolidDown.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidDown);

                    newSolidCentroid = new Point3d(solidCentroid.X,
                                                   solidCentroid.Y + (width - woodFrame) / 2,
                                                   solidCentroid.Z - (CountCover == 1 ? (flag / 2) : 0));
                    frameSolidRight.SetDatabaseDefaults();
                    frameSolidRight.CreateBox(length - 2 * woodFrame, woodFrame, minEdge - flag);
                    frameSolidRight.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidRight);

                    newSolidCentroid = new Point3d(solidCentroid.X,
                                                   solidCentroid.Y - (width - woodFrame) / 2,
                                                   solidCentroid.Z - (CountCover == 1 ? (flag / 2) : 0));
                    frameSolidLeft.SetDatabaseDefaults();
                    frameSolidLeft.CreateBox(length - 2 * woodFrame, woodFrame, minEdge - flag);
                    frameSolidLeft.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                    wFrame.Add(frameSolidLeft);

                    if (width >= CommandClass.MaxEdge)
                    {
                        newSolidCentroid = new Point3d(solidCentroid.X,
                                                       solidCentroid.Y,
                                                       solidCentroid.Z - (CountCover == 1 ? (flag / 2) : 0));
                        Solid3d middleEdge = new Solid3d();
                        middleEdge.SetDatabaseDefaults();
                        middleEdge.CreateBox(length - 2 * woodFrame, woodFrame, minEdge - flag);
                        middleEdge.TransformBy(Matrix3d.Displacement(newSolidCentroid - Point3d.Origin));
                        wFrame.Add(middleEdge);
                    }
                }
            }

            return wFrame;
        }
    }
}
