/*
 * Most of this image pan & zoom code is from the answer at
 * https://stackoverflow.com/questions/741956/pan-zoom-image
 * by user
 * https://stackoverflow.com/users/282801/wies%c5%82aw-%c5%a0olt%c3%a9s
 */

using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace realestatefinder
{
    public class ZoomBorder : Border
    {
        private Image child = null;
        private Point origin;
        private Point start;

        private double maxZoom = 100 * 0.2 + 1.0;
        private double minZoom = 1.0;

        public delegate void TransformUpdateHandler(object sender);
        public event TransformUpdateHandler OnUpdateTransform;

        public TranslateTransform GetTranslateTransform()
        {
            return (TranslateTransform)((TransformGroup)child.RenderTransform)
              .Children.First(tr => tr is TranslateTransform);
        }

        public ScaleTransform GetScaleTransform()
        {
            return (ScaleTransform)((TransformGroup)child.RenderTransform)
              .Children.First(tr => tr is ScaleTransform);
        }

        public override UIElement Child
        {
            get { return base.Child; }
            set
            {
                if (value != null && value != this.Child)
                    this.Initialize((Image)value);
                base.Child = value;
            }
        }

        public void Initialize(Image element)
        {
            this.child = element;
            if (child != null)
            {
                TransformGroup group = new TransformGroup();
                ScaleTransform st = new ScaleTransform();
                group.Children.Add(st);
                TranslateTransform tt = new TranslateTransform();
                group.Children.Add(tt);
                child.RenderTransform = group;
                child.RenderTransformOrigin = new Point(0.0, 0.0);
                this.MouseWheel += child_MouseWheel;
                this.MouseLeftButtonDown += child_MouseLeftButtonDown;
                this.MouseLeftButtonUp += child_MouseLeftButtonUp;
                this.MouseMove += child_MouseMove;
            }
        }

        public void Reset()
        {
            if (child != null)
            {
                // reset zoom
                var st = GetScaleTransform();
                st.ScaleX = 1.0;
                st.ScaleY = 1.0;

                // reset pan
                var tt = GetTranslateTransform();
                tt.X = 0.0;
                tt.Y = 0.0;
            }
        }

        #region Child Events

        private void child_MouseWheel(object sender, MouseWheelEventArgs e)
        {            
            if (child != null)
            {
                ScaleContent(e.GetPosition(child), e.Delta > 0, 1.0);
            }
        }

        private void child_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (child != null)
            {
                var tt = GetTranslateTransform();
                start = e.GetPosition(this);
                origin = new Point(tt.X, tt.Y);
                this.Cursor = Cursors.Hand;
                child.CaptureMouse();               
            }
        }

        private void child_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (child != null)
            {
                child.ReleaseMouseCapture();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void child_MouseMove(object sender, MouseEventArgs e)
        {
            if (child != null)
            {
                if (child.IsMouseCaptured)
                {
                    Vector v = start - e.GetPosition(this);
                    TranslateContent(v);
                }
            }
        }
        
        #endregion

        #region Tranformation Methods

        public void ScaleContent(Point scalePoint, bool zoomIn, double amount)
        {
            if (child != null)
            {
                var st = GetScaleTransform();
                var tt = GetTranslateTransform();

                double zoom = zoomIn ? .2 * amount : -.2 * amount;
                if (!zoomIn && (st.ScaleX < .4 || st.ScaleY < .4))
                    return;

                double absoluteX;
                double absoluteY;

                absoluteX = scalePoint.X * st.ScaleX + tt.X;
                absoluteY = scalePoint.Y * st.ScaleY + tt.Y;

                if ((st.ScaleY + zoom <= maxZoom) && (st.ScaleY + zoom >= minZoom))
                {
                    st.ScaleX += zoom;
                    st.ScaleY += zoom;

                    tt.X = absoluteX - scalePoint.X * st.ScaleX;
                    tt.Y = absoluteY - scalePoint.Y * st.ScaleY;

                    OnUpdateTransform?.Invoke(this);
                }
            }
        }

        public void TranslateContent(Vector translateVector)
        {
            if (child != null)
            {
                var st = GetScaleTransform();
                var tt = GetTranslateTransform();

                tt.X = origin.X - translateVector.X;
                tt.Y = origin.Y - translateVector.Y;

                OnUpdateTransform?.Invoke(this);
            }
        }

        #endregion
    }
}