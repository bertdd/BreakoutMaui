namespace MauiBreakout2
{
    internal class Background : Image
    {
        private readonly string[] imageSources = { "background.jpg", "background2.jpg" };
        private int currentImageIndex = 0;

        [Obsolete]
        public Background()
        {
            Source = imageSources[currentImageIndex];
            Aspect = Aspect.AspectFill;

            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                currentImageIndex = (currentImageIndex + 1) % imageSources.Length;
                var nextImageSource = imageSources[currentImageIndex];

                this.FadeTo(0, 1000, Easing.Linear).ContinueWith((t) =>
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        Source = nextImageSource;
                        this.FadeTo(1, 3000, Easing.Linear);
                    });
                });

                return true;
            });
        }
    }
}