using System;
using System.Collections.Generic;
using System.Drawing;

namespace DLLibs.Vectors
{
    internal class VectorList
    {
        private readonly int          _maxHeight;
        private readonly int          _maxWidth;
        private readonly List<Vector> _vectors;

        #region Init

        public VectorList(int width, int height) {
            _vectors   = new List<Vector>();
            _maxHeight = height;
            _maxWidth  = width;
        }

        #endregion

        #region Methods

        public int Count => _vectors.Count;

        public Vector this[int index] {
            get => _vectors[index];
            set => _vectors[index] = value;
        }

        #endregion

        #region Public Functions

        public bool Create(bool isRandom) {
            return isRandom
                       ? CreateVectorRandom()
                       : CreateVectorCustom();
        }

        public bool Delete(int index) {
            try {
                _vectors.RemoveAt(index);
                return true;
            } catch {
                return false;
            }
        }

        public Tuple<int, VectorsEditing> FindFirst(Point point) {
            var minEpsilon  = double.MaxValue;
            var index       = -1;
            var editingType = VectorsEditing.False;
            for (var i = 0;
                 i < _vectors.Count;
                 i++) {
                var epsilon = _vectors[i].IsInLine(point);

                if (epsilon <= 5 &&
                    epsilon < minEpsilon) {
                    index = i;
                    editingType = _vectors[i].StartPointPressed(point)
                                      ? VectorsEditing.StartPoint
                                      : _vectors[i].EndPointPressed(point)
                                          ? VectorsEditing.EndPoint
                                          : VectorsEditing.Center;
                }
            }

            return new Tuple<int, VectorsEditing>(index, editingType);
        }

        public Vector Pop() { return _vectors[_vectors.Count - 1]; }

        public bool EditVector(int index, Point point, VectorsEditing editingType) {
            switch (editingType) {
                case VectorsEditing.StartPoint: {
                    _vectors[index].StartPoint = point;
                    return true;
                }

                case VectorsEditing.EndPoint: {
                    _vectors[index].EndPoint = point;
                    return true;
                }

                case VectorsEditing.Center: {
                    var prevStartPoint = _vectors[index].StartPoint;
                    var prevEndPoint   = _vectors[index].EndPoint;
                    _vectors[index].StartPoint = new Point(prevStartPoint.X + point.X, prevStartPoint.Y + point.Y);
                    _vectors[index].EndPoint   = new Point(prevEndPoint.X   + point.X, prevEndPoint.Y   + point.Y);
                    break;
                }
            }

            return false;
        }

        #endregion

        #region Private Funcitons

        private bool CreateVectorRandom() {
            try {
                var rnd        = new Random();
                var startPoint = new Point(rnd.Next(15, _maxWidth - 15), rnd.Next(15, _maxHeight - 15));
                var endPoint   = new Point(rnd.Next(15, _maxWidth - 15), rnd.Next(15, _maxHeight - 15));
                var newVector  = new Vector(startPoint, endPoint);
                _vectors.Add(newVector);
                return true;
            } catch {
                return false;
            }
        }

        private bool CreateVectorCustom() { return false; }

        #endregion
    }
}