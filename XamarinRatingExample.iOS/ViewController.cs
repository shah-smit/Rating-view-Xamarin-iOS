using System;

using UIKit;

namespace XamarinRatingExample.iOS
{
    public partial class ViewController : UIViewController
    {

        private UIView ratingView;
        private UIButton oneStar, twoStar, threeStar, fourStar, fiveStar;
        private UITextView userRating;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ratingView = new UIView();
            ratingView.Frame = new CoreGraphics.CGRect(0, 20, this.View.Frame.Width, this.View.Frame.Height-20);
            addRatingView();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void addRatingView()
        {
            var ratingViewWidth = ratingView.Frame.Width;

            UIView ratingButtons = new UIView();
            ratingButtons.Frame = new CoreGraphics.CGRect(0, 20, ((ratingViewWidth / 2)), ratingView.Frame.Height);

            var starWidthHeight = ratingButtons.Frame.Width / 5;

            oneStar = new UIButton();
            oneStar.Frame = new CoreGraphics.CGRect(0, 0, starWidthHeight, starWidthHeight);
            oneStar.SetImage(new UIImage("star_empty.png"), UIControlState.Normal);
            oneStar.Tag = 1;
            oneStar.TouchUpInside += Rating_TouchUpInside;
            ratingButtons.AddSubview(oneStar);

            twoStar = new UIButton();
            twoStar.Frame = new CoreGraphics.CGRect(oneStar.Frame.Width, 0, starWidthHeight, starWidthHeight);
            twoStar.Tag = 2;
            twoStar.Frame = new CoreGraphics.CGRect(oneStar.Frame.Width, 0, starWidthHeight, starWidthHeight);
            twoStar.SetImage(new UIImage("star_empty.png"), UIControlState.Normal);
            twoStar.Tag = 2;
            twoStar.TouchUpInside += Rating_TouchUpInside;
            ratingButtons.AddSubview(twoStar);

            threeStar = new UIButton();
            threeStar.Frame = new CoreGraphics.CGRect(oneStar.Frame.Width + twoStar.Frame.Width, 0, starWidthHeight, starWidthHeight);
            threeStar.SetImage(new UIImage("star_empty.png"), UIControlState.Normal);
            threeStar.Tag = 3;
            threeStar.TouchUpInside += Rating_TouchUpInside;
            ratingButtons.AddSubview(threeStar);

            fourStar = new UIButton();
            fourStar.Frame = new CoreGraphics.CGRect(oneStar.Frame.Width + twoStar.Frame.Width + threeStar.Frame.Width, 0, starWidthHeight, starWidthHeight);
            fourStar.SetImage(new UIImage("star_empty.png"), UIControlState.Normal);
            fourStar.Tag = 4;
            fourStar.TouchUpInside += Rating_TouchUpInside;
            ratingButtons.AddSubview(fourStar);

            fiveStar = new UIButton();
            fiveStar.Frame = new CoreGraphics.CGRect(oneStar.Frame.Width + twoStar.Frame.Width + threeStar.Frame.Width + fourStar.Frame.Width, 0, starWidthHeight, starWidthHeight);
            fiveStar.SetImage(new UIImage("star_empty.png"), UIControlState.Normal);
            fiveStar.Tag = 5;
            fiveStar.TouchUpInside += Rating_TouchUpInside;
            ratingButtons.AddSubview(fiveStar);
            //initialiseRatingView(ratingButtons, starWidthHeight);

            ratingView.AddSubview(ratingButtons);

            userRating = new UITextView();
            userRating.Text = "";
            userRating.Font = UIFont.FromName("Helvetica", 15f);
            userRating.TextAlignment = UITextAlignment.Right;
            userRating.UserInteractionEnabled = false;
            userRating.Frame = new CoreGraphics.CGRect(ratingButtons.Frame.Width, 0, (ratingViewWidth / 2), ratingView.Frame.Height);
            ratingView.AddSubview(userRating);

            this.View.AddSubview(ratingView);
        }
        void Rating_TouchUpInside(object sender, EventArgs e)
        {
            UIButton button = sender as UIButton;
            updateRating((int)button.Tag);
        }

        void updateRating(int rating)
        {
            UIButton[] arrayofButton = { oneStar, twoStar, threeStar, fourStar, fiveStar };

            for (int i = 0; i < arrayofButton.Length; i++)
            {
                if (i <= rating - 1)
                {
                    arrayofButton[i].SetImage(UIImage.FromFile("star_filled.png"), UIControlState.Normal);
                }
                else
                {
                    arrayofButton[i].SetImage(UIImage.FromFile("star_empty.png"), UIControlState.Normal);
                }
            }
            userRating.Text = "User \n" + rating;
        }
    }
}

