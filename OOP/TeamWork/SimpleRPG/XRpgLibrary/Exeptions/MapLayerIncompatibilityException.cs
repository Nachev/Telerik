namespace XTankWarsLibrary.Exeptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class MapLayerIncompatibilityException : ApplicationException
    {
        private readonly int layerIndex;

        public MapLayerIncompatibilityException()
        {
        }

        public MapLayerIncompatibilityException(int layerIndex)
            : base(FormatMessage(layerIndex))
        {
            this.layerIndex = layerIndex;
        }

        public MapLayerIncompatibilityException(string message)
            : base(message)
        {
        }

        public MapLayerIncompatibilityException(int layerIndex, Exception inner)
            : base(FormatMessage(layerIndex), inner)
        {
            this.layerIndex = layerIndex;
        }

        public MapLayerIncompatibilityException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected MapLayerIncompatibilityException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            this.layerIndex = info.GetInt32("data");
        }

        public int LayerIndex
        {
            get
            {
                return this.layerIndex;
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("data", this.layerIndex);
            base.GetObjectData(info, context);
        }

        private static string FormatMessage(int layerIndex)
        {
            return string.Format("Map Layer Incompatibility Exception index: {0}", layerIndex);
        }
    }
}
