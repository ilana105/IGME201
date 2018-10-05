using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Graphics;
using System;

namespace ColorPicker
{
    [Activity(Label = "ColorPicker", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText redEditText, greenEditText, blueEditText;
        View previewColor;
        TextView hexValue;
        Button ps_red, ps_green, ps_blue, ps_yellow, ps_pink, ps_lightblue, ps_lightgreen, ps_lightyellow, toggleButton;
        GridLayout rgbNumber, sliderLayout;
        SeekBar redSlider, greenSlider, blueSlider;
        int red, green, blue = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            rgbNumber = FindViewById<GridLayout>(Resource.Id.gridLayout1);
            sliderLayout = FindViewById<GridLayout>(Resource.Id.gridLayout2);
            rgbNumber.Visibility = ViewStates.Visible;
            sliderLayout.Visibility = ViewStates.Gone;

            redEditText = FindViewById<EditText>(Resource.Id.redText);
            blueEditText = FindViewById<EditText>(Resource.Id.blueText);
            greenEditText = FindViewById<EditText>(Resource.Id.greenText);
            redEditText.Visibility = (ViewStates.Visible);

            redSlider = FindViewById<SeekBar>(Resource.Id.redSeekBar);
            greenSlider = FindViewById<SeekBar>(Resource.Id.greenSeekBar);
            blueSlider = FindViewById<SeekBar>(Resource.Id.blueSeekBar);

            previewColor = FindViewById<View>(Resource.Id.colorView);
            hexValue = FindViewById<TextView>(Resource.Id.hexText);

            toggleButton = FindViewById<Button>(Resource.Id.toggleButton);

            ps_red = FindViewById<Button>(Resource.Id.ps_red);
            ps_green = FindViewById<Button>(Resource.Id.ps_green);
            ps_blue = FindViewById<Button>(Resource.Id.ps_blue);
            ps_yellow = FindViewById<Button>(Resource.Id.ps_yellow);
            ps_pink = FindViewById<Button>(Resource.Id.ps_pink);
            ps_lightblue = FindViewById<Button>(Resource.Id.ps_light_purple);
            ps_lightgreen = FindViewById<Button>(Resource.Id.ps_light_green);
            ps_lightyellow = FindViewById<Button>(Resource.Id.ps_light_yellow);

            redEditText.TextChanged += RedEditText_TextChanged;
            blueEditText.TextChanged += BlueEditText_TextChanged;
            greenEditText.TextChanged += GreenEditText_TextChanged;

            redSlider.ProgressChanged += RedSlider_ProgressChanged;
            greenSlider.ProgressChanged += GreenSlider_ProgressChanged;
            blueSlider.ProgressChanged += BlueSlider_ProgressChanged;

            toggleButton.Click += ToggleButton_Click;

            ps_red.Click += Ps_red_Click;
            ps_green.Click += Ps_green_Click;
            ps_blue.Click += Ps_blue_Click;
            ps_yellow.Click += Ps_yellow_Click;
            ps_pink.Click += Ps_pink_Click;
            ps_lightblue.Click += Ps_lightblue_Click;
            ps_lightgreen.Click += Ps_lightgreen_Click;
            ps_lightyellow.Click += Ps_lightyellow_Click;
            
        }

        private void BlueSlider_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            blue = e.Progress;
            blueEditText.Text = (e.Progress).ToString();

            if (blue > 255)
                blue = 255;

            else if (blue < 0)
                blue = 0;

            ChangeColor();
        }

        private void GreenSlider_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            green = e.Progress;
            greenEditText.Text = (e.Progress).ToString();

            if (green > 255)
                green = 255;

            else if (green < 0)
                green = 0;

            ChangeColor();
        }

        private void RedSlider_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            red = e.Progress;
            redEditText.Text = (e.Progress).ToString();

            if (red > 255)
                red = 255;

            else if (red < 0)
                red = 0;

            ChangeColor();
        }

        private void Ps_lightyellow_Click(object sender, EventArgs e)
        {
            hexValue.Text = "#FFFF99";
            previewColor.SetBackgroundColor(Color.Rgb(255, 255, 153));
            redEditText.Text = "255";
            greenEditText.Text = "255";
            blueEditText.Text = "153";
            redSlider.Progress = 255;
            greenSlider.Progress = 255;
            blueSlider.Progress = 153;
        }

        private void Ps_lightgreen_Click(object sender, EventArgs e)
        {
            hexValue.Text = "#99FF99";
            previewColor.SetBackgroundColor(Color.Rgb(153, 255, 153));
            redEditText.Text = "153";
            greenEditText.Text = "255";
            blueEditText.Text = "153";
            redSlider.Progress = 153;
            greenSlider.Progress = 255;
            blueSlider.Progress = 153;
        }

        private void Ps_lightblue_Click(object sender, EventArgs e)
        {
            hexValue.Text = "#9999FF";
            previewColor.SetBackgroundColor(Color.Rgb(153, 153, 255));
            redEditText.Text = "153";
            greenEditText.Text = "153";
            blueEditText.Text = "255";
            redSlider.Progress = 153;
            greenSlider.Progress = 153;
            blueSlider.Progress = 255;
        }

        private void Ps_pink_Click(object sender, EventArgs e)
        {
            hexValue.Text = "#FF9999";
            previewColor.SetBackgroundColor(Color.Rgb(255, 153, 153));
            redEditText.Text = "255";
            greenEditText.Text = "153";
            blueEditText.Text = "153";
            redSlider.Progress = 255;
            greenSlider.Progress = 153;
            blueSlider.Progress = 153;
        }

        private void Ps_yellow_Click(object sender, EventArgs e)
        {
            hexValue.Text = "#FFFF00";
            previewColor.SetBackgroundColor(Color.Rgb(255, 255, 0));
            redEditText.Text = "255";
            greenEditText.Text = "255";
            blueEditText.Text = "0";
            redSlider.Progress = 255;
            greenSlider.Progress = 255;
            blueSlider.Progress = 0;
        }

        private void Ps_blue_Click(object sender, EventArgs e)
        {
            hexValue.Text = "#0000FF";
            previewColor.SetBackgroundColor(Color.Rgb(0, 0, 255));
            redEditText.Text = "0";
            greenEditText.Text = "0";
            blueEditText.Text = "255";
            redSlider.Progress = 0;
            greenSlider.Progress = 0;
            blueSlider.Progress = 255;
        }

        private void Ps_green_Click(object sender, EventArgs e)
        {
            hexValue.Text = "#00FF00";
            previewColor.SetBackgroundColor(Color.Rgb(0, 255, 0));
            redEditText.Text = "0";
            greenEditText.Text = "255";
            blueEditText.Text = "0";
            redSlider.Progress = 0;
            greenSlider.Progress = 255;
            blueSlider.Progress = 0;
        }

        private void Ps_red_Click(object sender, EventArgs e)
        {
            hexValue.Text = "#FF0000";
            previewColor.SetBackgroundColor(Color.Rgb(255, 0, 0));
            redEditText.Text = "255";
            greenEditText.Text = "0";
            blueEditText.Text = "0";
            redSlider.Progress = 255;
            greenSlider.Progress = 0;
            blueSlider.Progress = 0;
        }

        private void ToggleButton_Click(object sender, EventArgs e)
        {
            if (rgbNumber.Visibility == ViewStates.Visible)
            {
                rgbNumber.Visibility = ViewStates.Gone;
                sliderLayout.Visibility = ViewStates.Visible;
            }
            else
            {
                rgbNumber.Visibility = ViewStates.Visible;
                sliderLayout.Visibility = ViewStates.Gone;
            }
        }

        private void GreenEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            green = int.Parse(greenEditText.Text);
            greenSlider.Progress = green;

            if (green > 255)
                green = 255;

            else if (green < 0)
                green = 0;

            ChangeColor();
        }

        private void BlueEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            blue = int.Parse(blueEditText.Text);
            blueSlider.Progress = blue;

            if (blue > 255)
                blue = 255;

            else if (blue < 0)
                blue = 0;

            ChangeColor();
        }

        private void RedEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            red = int.Parse(redEditText.Text);
            redSlider.Progress = red;

            if (red > 255)
                red = 255;

            else if (red < 0)
                red = 0;

            ChangeColor();
        }

        private void ChangeColor()
        {
            previewColor.SetBackgroundColor(Color.Rgb(red, green, blue));
            HexConvert(Color.Rgb(red, green, blue));
        }


        private string HexConvert (Color c)
        {
            return hexValue.Text = "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
    }
}

