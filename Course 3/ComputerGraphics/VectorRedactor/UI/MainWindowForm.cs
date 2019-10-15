using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLLibs;

namespace VectorRedactor.UI
{
    public partial class MainWindowForm : Form
    {
        private bool _isMouseMove;
        private bool _isVectorEdited;
        private Point _startPoint;
        private Imager _image;

        #region Private Functions

        private void UpdateGeneralInfo() {
            var generalInfo = _image.GetGeneralInfo;
            CountOfVectorsLbl.Text = generalInfo["VectorsCount"];
        }

        private void UpdateCanvas() {
            UpdateGeneralInfo();
            _image.FullRefresh();
            Canvas.Refresh();
        }

        #endregion

        #region Init

        public MainWindowForm()
        {
            InitializeComponent();
        }

        private void HandleLoadMainWindow(object sender, EventArgs e) {

            _image = new Imager(Canvas.Width, Canvas.Height);
            Canvas.Image = _image.Canvas;
            UpdateCanvas();
        }

        #endregion

        #region Manipulations on vectors

        private void HandleClickInsertVector(object sender, EventArgs e) {
            _image.CreateVector(true);
            UpdateGeneralInfo();
            Canvas.Refresh();
        }

        private void HandleClickRemoveVector(object sender, EventArgs e) {
            _image.RemoveVector();
            RemoveVectorBtn.Enabled = false;
            UpdateCanvas();
        }

        #endregion

        #region Canvas

        private void HandleMouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) return;
            _isVectorEdited         = _image.FindVector(e.Location);
            RemoveVectorBtn.Enabled = _isVectorEdited;
            Canvas.Refresh();

            _isMouseMove = true;
            _startPoint = e.Location;
        }

        private void HandleMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) _isMouseMove = false;

            if (!_isMouseMove ||
                !_isVectorEdited) return;

            var location = e.Location;
            if (_image.GetEditingType == VectorsEditing.Center) {
                location    = new Point(e.X - _startPoint.X, e.Y - _startPoint.Y);
                _startPoint = e.Location;
            }
            _image.EditVector(location);
            UpdateCanvas();
        }

        private void HandleMouseUp(object sender, MouseEventArgs e) {
            _isMouseMove = false;
            UpdateCanvas();
        }

        #endregion
    }
}
