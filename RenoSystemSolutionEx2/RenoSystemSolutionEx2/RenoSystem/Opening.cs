using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenoSystem
{
    public class Opening
    {
        //  data fields (data members)

        private int _Edging;
        private int _Height;
        private int _Width;

        //Constants (Minimum Requirements)
        private const int _EDGING = 10; //if edging is present
        private const int _HEIGHT = 120;
        private const int _WIDTH = 50;

        //  properties

        public int Area
        {
            get
            {
                return _Width * _Height;
            }
        }

        public int Edging
        {
            get
            {
                return _Edging;
            }

            set
            {
                if (!Utilities.IsZeroPositive(value))
                {
                    throw new ArgumentException($"The Edging value: {value} is invalid. Must be a positive value.");
                }

                if (!Utilities.IsValidMinimum(value, _EDGING) && (value !=0))
                {
                    throw new ArgumentException($"The Edging should be a minimum of {_EDGING} cm if required.");
                }
                _Edging = value;
            }
        }

        public int Height
        {
            get
            {
                return _Height;
            }

            set
            {
                if (!Utilities.IsNonZeroPositive(value))
                {
                    throw new ArgumentException($"The Height value: {value} is invalid. Must be a positive value.");
                }

                if (!Utilities.IsValidMinimum(value, _HEIGHT))
                {
                    throw new ArgumentException($"The Height should be a minimum of {_HEIGHT} cm");
                }
                _Height = value;
            }
        }


        public int Perimeter
        {
            get
            {
                return (_Width + _Height) * 2;
            }
        }

        public OpeningType Type
        {
            get;
            set;
        }


        public int Width
        {
            get
            {
                return _Width;
            }

            set
            {
                if (!Utilities.IsNonZeroPositive(value))
                {
                    throw new ArgumentException($"The Width value: {value} is invalid. Must be a positive value.");
                }

                if (!Utilities.IsValidMinimum(value, _WIDTH))
                {
                    throw new ArgumentException($"The Width should be a minimum of {_WIDTH} cm");
                }

                _Width = value;
            }
        }

        //  behaviours

        public Opening(int width, int height, OpeningType type, int edging = 0)
        {
            Type = type;
            Width = width;
            Height = height;
            Edging = edging;

        }

        public override string ToString()
        {
            return $"{Width},{Height},{Type},{Edging}";
        }
    }
}
