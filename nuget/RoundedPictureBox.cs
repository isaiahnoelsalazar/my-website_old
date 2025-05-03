using System.Runtime.InteropServices;

namespace mywebsite_nugetpackage
{
    public class RoundedPictureBox : PictureBox
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);

        public void InitializeRoundedPictureBox(int roundness)
        {
            base.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, base.Width, base.Height, roundness, roundness));
        }
    }

}
