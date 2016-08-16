using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OmronCameraDemo
{
    /// <summary >
    /// OKAO parameter settings
    /// </summary >
    public partial class Params : Form
    {
        ClassHvcw clsHvcw;

        public Params()
        {
            InitializeComponent();
        }

        // ***** Dialog display *****
        public void SetDialog(IWin32Window owner, ClassHvcw refHvcw)
        {
            clsHvcw = refHvcw;

            // Get from camera current parameters
            if (clsHvcw.GetParams() == ClassHvcw.HVCW_SUCCESS)
            {
                numericBdMin.Value = clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_body_nMin];
                numericBdMax.Value = clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_body_nMax];
                numericHdMin.Value = clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_hand_nMin];
                numericHdMax.Value = clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_hand_nMax];
                numericPdMin.Value = clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_pet_nMin];
                numericPdMax.Value = clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_pet_nMax];
                numericDtMin.Value = clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_face_nMin];
                numericDtMax.Value = clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_face_nMax];

                numericBdThresh.Value = clsHvcw.threshold[ClassHvcw.HVCW_OKAO_THRESHOLD_nBody];
                numericHdThresh.Value = clsHvcw.threshold[ClassHvcw.HVCW_OKAO_THRESHOLD_nHand];
                numericPdThresh.Value = clsHvcw.threshold[ClassHvcw.HVCW_OKAO_THRESHOLD_nPet];
                numericDtThresh.Value = clsHvcw.threshold[ClassHvcw.HVCW_OKAO_THRESHOLD_nFace];
                numericRecogThresh.Value = clsHvcw.threshold[ClassHvcw.HVCW_OKAO_THRESHOLD_nRecognition];
            }
            this.ShowDialog(owner);
        }

        // ***** Parameter settings *****
        private void button1_Click(object sender, EventArgs e)
        {
            clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_body_nMin] = (int)numericBdMin.Value;
            clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_body_nMax] = (int)numericBdMax.Value;
            clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_hand_nMin] = (int)numericHdMin.Value;
            clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_hand_nMax] = (int)numericHdMax.Value;
            clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_pet_nMin] = (int)numericPdMin.Value;
            clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_pet_nMax] = (int)numericPdMax.Value;
            clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_face_nMin] = (int)numericDtMin.Value;
            clsHvcw.sizeRange[ClassHvcw.HVCW_OKAO_SIZE_RANGE_face_nMax] = (int)numericDtMax.Value;

            clsHvcw.threshold[ClassHvcw.HVCW_OKAO_THRESHOLD_nBody] = (int)numericBdThresh.Value;
            clsHvcw.threshold[ClassHvcw.HVCW_OKAO_THRESHOLD_nHand] = (int)numericHdThresh.Value;
            clsHvcw.threshold[ClassHvcw.HVCW_OKAO_THRESHOLD_nPet] = (int)numericPdThresh.Value;
            clsHvcw.threshold[ClassHvcw.HVCW_OKAO_THRESHOLD_nFace] = (int)numericDtThresh.Value;
            clsHvcw.threshold[ClassHvcw.HVCW_OKAO_THRESHOLD_nRecognition] = (int)numericRecogThresh.Value;

            if (clsHvcw.SetParams() == ClassHvcw.HVCW_SUCCESS)
            {
                MessageBox.Show("Parameter settings successful", "OK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Parameter settings failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
