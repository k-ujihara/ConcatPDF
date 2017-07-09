using iText.Kernel.Pdf;
using static iText.Kernel.Pdf.PdfViewerPreferences;

namespace Ujihara.PDF
{
    public class PageViewerPreferences
    {
        public PdfName PageLayout { get; set; }
        public PdfName PageMode { get; set; }

        public PdfViewerPreferencesConstants NonFullScreenPageMode { get; set; }
        public bool HideToolbar { get; set; }
        public bool HideMenubar { get; set; }
        public bool HideWindowUI { get; set; }
        public bool FitWindow { get; set; }
        public bool CenterWindow { get; set; }

        public PdfViewerPreferences ViewerPreferences
        {
            get
            {
                PdfViewerPreferences viewerPreference = new PdfViewerPreferences();
                if (PageMode == PdfName.FullScreen)
                {
                    viewerPreference.SetNonFullScreenPageMode(NonFullScreenPageMode);
                }
                viewerPreference.SetHideToolbar(HideToolbar);
                viewerPreference.SetHideMenubar(HideMenubar);
                viewerPreference.SetHideWindowUI(HideWindowUI);
                viewerPreference.SetFitWindow(FitWindow);
                viewerPreference.SetCenterWindow(CenterWindow);

                return viewerPreference;
            }
        }
    }
}
