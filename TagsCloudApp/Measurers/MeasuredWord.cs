using System;

namespace TagsCloudVisualization.Measurers
{
    public class MeasuredWord
    {
        public string Value { get; }
        public double Weight { get; }

        public double Eps { get; set; } = 10e-5;

        public MeasuredWord(string value, double weight)
        {
            if (weight < 0 - Eps || weight > 1 + Eps)
                throw new ArgumentException("Word weight should be in range [0, 1]");
            Value = value;
            Weight = weight;
        }

        protected bool Equals(MeasuredWord other)
        {
            return string.Equals(Value, other.Value) && Math.Abs(Weight - other.Weight) < Eps;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((MeasuredWord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value?.GetHashCode() ?? 0)*397) ^ Weight.GetHashCode();
            }
        }
    }
}