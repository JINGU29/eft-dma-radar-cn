using SkiaSharp;

namespace eft_dma_radar.Common.Misc
{
    public static class CustomFonts
    {
        public static SKTypeface SKFontFamilyRegular { get; }
        public static SKTypeface SKFontFamilyBold { get; }
        public static SKTypeface SKFontFamilyItalic { get; }
        public static SKTypeface SKFontFamilyMedium { get; }

        static CustomFonts()
        {
            try
            {
                var msyh = SKTypeface.FromFamilyName("Microsoft YaHei") ?? SKTypeface.Default;
                SKFontFamilyRegular = msyh;
                SKFontFamilyBold = msyh;
                SKFontFamilyItalic = msyh;
                SKFontFamilyMedium = msyh;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERROR Loading Custom Fonts!", ex);
            }
        }
    }
}
