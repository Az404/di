namespace TagsCloudVisualization
{
    public class MeasuredWord
    {
        public string Value { get; set; }
        public int Weight { get; set; }

        public MeasuredWord(string value, int weight)
        {
            Value = value;
            Weight = weight;
        }

        protected bool Equals(MeasuredWord other)
        {
            return string.Equals(Value, other.Value) && Weight == other.Weight;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MeasuredWord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value?.GetHashCode() ?? 0)*397) ^ Weight;
            }
        }
    }
}