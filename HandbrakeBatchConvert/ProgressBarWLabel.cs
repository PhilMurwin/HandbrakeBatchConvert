using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProgressBarWithLabel
{
    public enum ProgressBarDisplayText
    {
        Percentage,
        CustomText
    }

    class ProgressBarWLabel : ProgressBar
    {
        //Property to set to decide whether to print a % or Text
        public ProgressBarDisplayText DisplayStyle { get; set; }

        //Property to hold the custom text
        public String CustomText { get; set; }

        public ProgressBarWLabel()
        {
            // Modify the ControlStyles flags
            //http://msdn.microsoft.com/en-us/library/system.windows.forms.controlstyles.aspx
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = ClientRectangle;
            Graphics g = e.Graphics;

            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            rect.Inflate(-3, -3);

            if (Value > 0)
            {
                // As we doing this ourselves we need to draw the chunks on the progress bar
                Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)Value / Maximum) * rect.Width), rect.Height);
                ProgressBarRenderer.DrawHorizontalChunks(g, clip);
            }

            // Set the Display text (Either a % amount or our custom text
            string text = DisplayStyle == ProgressBarDisplayText.Percentage ? Value.ToString() + '%' : CustomText;

            using (Font textFont = new Font("Arial", 10, FontStyle.Bold))
            {
                var shadowFont = new Font(textFont.FontFamily, textFont.Size + 1, textFont.Style);
                var shadowBrush = new SolidBrush(Color.White);
                var shadowOffset = new SizeF(1, 0);
                var textBrush = new SolidBrush(Color.Black);

                // Measure the string to see how big the image will be
                SizeF textSize = g.MeasureString(text, textFont);

                // Calculate the location of the text (the middle of progress bar)
                Point location = new Point(Convert.ToInt32((rect.Width / 2) - (textSize.Width / 2))
                    , Convert.ToInt32((rect.Height / 2) - (textSize.Height / 3)
                    ));

                // Draw the custom text
                g.DrawString(text, textFont, shadowBrush, location.X - shadowOffset.Width, location.Y);
                //g.DrawString( text, shadowFont, shadowBrush, location );
                g.DrawString(text, textFont, textBrush, location);
            }
        }
    }
}
