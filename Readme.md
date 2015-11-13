RazorPDF2
==============

RazorPDF is a simple project that makes it a breeze to create PDFs using the Razor view engine. Since Razor is really a template syntax, it can do lot more than just generate HTML. RazorPDF uses it to generate iText XML older notation. Then using the iTextSharp library, we turn that iText XML into a PDF to return. The end result is a easy to use, clean method for generating PDFs.

This project is a continuation from original Al Nyveldt's project. Apparently the guy died since 2013 and all the pull request made in the original repository (some of them made by me) were unanswered. This encouraged me to fork his repository and make the changes by myself, but is not simple as it seemed before.

[Bruno Lowagie, the creator of iTextSharp, RazorPDF's dependent library, said in this answer that the older syntax, supported by RazorPDF, should be discouraged,  arguing that the older syntax can cause a lot of bugs, etc.](http://stackoverflow.com/a/16109107/1314276), what left me with no options: I need to ensure compatibility with legacy systems and extend compatibility to iTextSharp 5.x.x without reimplement lots of ready and working templates. I respect Lowagie's decision to abandon an old template, but this is not a good decision for legacy systems, essentially when the library involved is a popular framework.

What I did in this project is to blend [RazorPDF](https://github.com/RazorAnt/RazorPDF), [iTextSharp 4.1.6](https://github.com/cigano/iTextSharp-4.1.6) and [MvcRazorToPdf](https://github.com/cigano/MvcRazorToPdf). I admit it's not the optimal solution, but at least works with all your project packages updated and without crashing anything. 

## Usage

The easiest way to get started with RazorPDF is to add the NuGet package to your MVC project:

    Install-Package RazorPDF2

There is a short screencast on [Nyveldt's blog](http://nyveldt.com/blog/page/razorpdf) to get you started so well as a sample project and some syntax samples.

## Acknowledgements

RazorPDF likely wouldn't exist without the [Spark view engine](http://sparkviewengine.com/). The ability to create PDFs with the Spark view engine is something I've missed often since switching to using Razor as my default view engine in MVC projects. Huge thanks to [Louis DeJardin](http://whereslou.com/) for putting together the Spark view engine many years ago and for the idea of mixing Spark with iTextSharp as a nice way to make PDFs.

Also, RazorPDF is worthless without [iTextSharp](http://sourceforge.net/projects/itextsharp/). Thanks so much to the team that works on that incredible project.

## License

RazorPDF2 is licensed under [MIT License](https://opensource.org/licenses/MIT). 
