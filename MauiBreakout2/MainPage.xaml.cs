namespace MauiBreakout2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var timer = Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromMilliseconds(25);
            timer.IsRepeating = true;
            timer.Tick += Timer_Tick!;
            timer.Start();

            viewArea.SizeChanged += Layout_SizeChanged!;
        }

        private void OnTapped(object sender, TappedEventArgs e)
        {
            var point = e.GetPosition(this);
            if (point != null)
            {
                var borisX = (point?.X / gameArea.Width * 2) - 1.0;
                boris.Move(gameArea, borisX);
            }
        }

        private void Layout_SizeChanged(object sender, EventArgs e)
        {
            boris.AnchorBottom(gameArea, Height);
            croco.AnchorBottom(gameArea, Height);
            cactus.AnchorBottom(gameArea, Height, 100);
            rainbow.AnchorBottom(gameArea, Height);
            gameArea.SetLayoutBounds(background, new Rect(0, 0, Width, Height));
        }

        double zoomStep = 0.005f;
        double zoomMax = 1.6f;
        double zoomMin = 1.0f;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Control.UseGameController())
            {
                boris.Move(gameArea, Control.GetX());
            }

            bird.Move(gameArea, boris);

            cloud1.MoveHorizontal(gameArea, 10);
            cloud2.MoveHorizontal(gameArea, 2);
            cloud3.MoveHorizontal(gameArea, 20);
            cloud4.MoveHorizontal(gameArea, 8);
            cloud5.MoveHorizontal(gameArea, -12);

            if (ZoomIN && zoomfactor < zoomMax)
            {
                zoomfactor += zoomStep;
            }
            if (!ZoomIN && zoomfactor > zoomMin)
            {
                zoomfactor -= zoomStep;
            }
            if (zoomfactor <= zoomMin || zoomfactor >= zoomMax)
            {
                ZoomIN = !ZoomIN;
            }

            background.Scale = zoomfactor;

            plane.MoveHorizontal(gameArea, -2);
            plane2.MoveHorizontal(gameArea, 10);
            croco.MoveHorizontal(gameArea, -0.5);
            rainbow.Tick();
            sun.Turn();
        }



        double zoomfactor = 1.0f;
        bool ZoomIN = true;

        readonly private PlayerControl Control = new();
    }
}