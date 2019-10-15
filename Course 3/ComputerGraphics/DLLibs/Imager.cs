using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DLLibs.Vectors;

namespace DLLibs
{
    public enum VectorsEditing
    {
        False,
        Center,
        StartPoint, 
        EndPoint
    }

    public class Imager
    {
        public Bitmap Canvas;
        private readonly Graphics _graphics;
        private readonly Pen _drawPen = new Pen(Color.Black, 3);
        private readonly Pen _rabberPen = new Pen(Color.Snow, 3)
                                    {
                                        StartCap = LineCap.RoundAnchor,
                                        EndCap = LineCap.RoundAnchor
                                    };
        private readonly VectorList _vectors;
        private int _selectedVector;

        private VectorsEditing _editingVectorType;

        #region Methods

        public VectorsEditing GetEditingType => _editingVectorType;
        public Dictionary<string, string> GetGeneralInfo {
            get {
                Dictionary<string, string> generalInfo = new Dictionary<string, string>
                                                             {
                                                                 {
                                                                     "VectorsCount", _vectors.Count.ToString()
                                                                 }
                                                             };
                return generalInfo;
            }
        }

        #endregion

        #region Init

        public Imager(int width, int height)
        {
            Canvas        = new Bitmap(width, height);
            _graphics = Graphics.FromImage(Canvas);
            _selectedVector = -1;
            _vectors         = new VectorList(width, height);
        }

        public Imager(int width, int height, int selectedVectors) {
            Canvas = new Bitmap(width, height);
            _graphics = Graphics.FromImage(Canvas);
            _selectedVector = selectedVectors;
            _vectors = new VectorList(width, height);
        }

        #endregion

        #region Public Functions

        public void FullRefresh() {
            _graphics.Clear(Color.Snow);
            for (int i = 0;
                 i < _vectors.Count;
                 i++) {
                if (_vectors[i].IsSelected) {
                    _drawPen.EndCap = LineCap.RoundAnchor;
                    _drawPen.StartCap = LineCap.RoundAnchor;
                }
                _graphics.DrawLine(_drawPen, _vectors[i].StartPoint, _vectors[i].EndPoint);
                _drawPen.EndCap = LineCap.NoAnchor;
                _drawPen.StartCap = LineCap.NoAnchor;
            }
        }

        #endregion

        #region Vectors

        public void EditVector(Point newPoint) {
            _graphics.DrawLine(_rabberPen, _vectors[_selectedVector].StartPoint, _vectors[_selectedVector].EndPoint);
            switch (_editingVectorType) {
                case VectorsEditing.Center: {
                    _vectors.EditVector(_selectedVector, newPoint, VectorsEditing.Center);
                    break;
                }

                case VectorsEditing.EndPoint: {
                    _vectors.EditVector(_selectedVector, newPoint, VectorsEditing.EndPoint);
                    break;
                }

                case VectorsEditing.StartPoint: {
                    _vectors.EditVector(_selectedVector, newPoint, VectorsEditing.StartPoint);
                    break;
                }
            }
            _graphics.DrawLine(_drawPen, _vectors[_selectedVector].StartPoint, _vectors[_selectedVector].EndPoint);
        }

        public bool CreateVector(bool isRandom) {
            var isVectorCreated = _vectors.Create(isRandom);
            if (!isVectorCreated) return false;

            var insertedVector = _vectors.Pop();
            _graphics.DrawLine(_drawPen, insertedVector.StartPoint, insertedVector.EndPoint);

            return true;
        }

        public bool RemoveVector() {
            var deletedVector = _vectors[_selectedVector];
            var isVectorDeleted = _vectors.Delete(_selectedVector);
            if (!isVectorDeleted) return false;

            _selectedVector = -1;
            _graphics.DrawLine(_rabberPen, deletedVector.StartPoint, deletedVector.EndPoint);
            return true;
        }

        public bool FindVector(Point clickedPoint) {
            var newSelectedVector = _vectors.FindFirst(clickedPoint);
            _editingVectorType = newSelectedVector.Item2;
            if (_selectedVector != -1)
            {
                var prevVector = _vectors[_selectedVector];
                _vectors[_selectedVector].IsSelected = false;
                _graphics.DrawLine(_rabberPen, prevVector.StartPoint, prevVector.EndPoint);
                _graphics.DrawLine(_drawPen,   prevVector.StartPoint, prevVector.EndPoint);
            }

            if (newSelectedVector.Item1 == -1) {
                _selectedVector = -1;
                return false;
            }

            _selectedVector = newSelectedVector.Item1;
            if (_selectedVector == -1) return false;

            var selectedVector = _vectors[_selectedVector];
            _drawPen.StartCap = LineCap.RoundAnchor;
            _drawPen.EndCap = LineCap.RoundAnchor;
            _graphics.DrawLine(_drawPen, selectedVector.StartPoint, selectedVector.EndPoint);
            _drawPen.StartCap = LineCap.NoAnchor;
            _drawPen.EndCap = LineCap.NoAnchor;
            _vectors[_selectedVector].IsSelected = true;

            return true;
        }

        #endregion
    }
}
