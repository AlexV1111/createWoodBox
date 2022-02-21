using System;
using System.Windows.Forms;

namespace Command
{
    public partial class FormWoodMaterial : Form
    {

        public FormWoodMaterial()
        {
            InitializeComponent();
            comboBox_WoodFrame.Items.AddRange(new string[] { "12", "16" });
            comboBox_WoodFrame.SelectedIndex = 1;
            CommandClass.woodFrame = int.Parse(comboBox_WoodFrame.SelectedItem.ToString());

            comboBox_WoodCover.Items.AddRange(new string[] { "3", "4", "5", "6" });
            comboBox_WoodCover.SelectedIndex = 3;
            CommandClass.woodCover = int.Parse(comboBox_WoodCover.SelectedItem.ToString());

            comboBox_CountCover.Items.AddRange(new string[] { "0", "1", "2" });
            comboBox_CountCover.SelectedIndex = 2;
            CommandClass.CountCover = int.Parse(comboBox_CountCover.SelectedItem.ToString());

            comboBox_WoodFrame.SelectedIndexChanged += comboBox_WoodFrame_SelectedIndexChanged;
            comboBox_WoodCover.SelectedIndexChanged += comboBox_WoodCover_SelectedIndexChanged;
            comboBox_CountCover.SelectedIndexChanged += comboBox_CountCover_SelectedIndexChanged;
        }

        void comboBox_WoodFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommandClass.woodFrame = int.Parse(comboBox_WoodFrame.SelectedItem.ToString());
        }

        void comboBox_WoodCover_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommandClass.woodCover = int.Parse(comboBox_WoodCover.SelectedItem.ToString());
        }

        void comboBox_CountCover_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommandClass.CountCover = int.Parse(comboBox_CountCover.SelectedItem.ToString());
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
