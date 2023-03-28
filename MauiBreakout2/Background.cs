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

                if (nextImageSource == "background2.jpg")
                {
                    this.FadeTo(0, 1000, Easing.Linear).ContinueWith((t) =>
                    {
                        Source = nextImageSource;
                        this.FadeTo(1, 5000, Easing.Linear);
                    });
                }
                else
                {
                    Source = nextImageSource;
                }

                return true;
            });
        }
    }
}