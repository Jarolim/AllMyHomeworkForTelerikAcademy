//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
 
////For converting HTML TO PDF- START
//using iTextSharp.text;
//using iTextSharp.text.html;
//using iTextSharp.text.pdf;
//using iTextSharp.text.xml;
//using iTextSharp.text.html.simpleparser;
//using System.IO;
//using System.util;
//using System.Text.RegularExpressions;
////For converting HTML TO PDF- END
 
//public partial class PostToPDF_AM22 : System.Web.UI.Page
//{
//    protected void Page_Load(object sender, EventArgs e)
//    {
//        //Get the HTML code from your database or whereever you have stored it and store
//        //it in HTMLCode variable.
//        string HTMLCode = string.Empty;
//        ConvertHTMLToPDF(HTMLCode);
//    }
//    protected void ConvertHTMLToPDF(string HTMLCode)
//    {
//        HttpContext context = HttpContext.Current;
        
//        //Render PlaceHolder to temporary stream 
//        System.IO.StringWriter stringWrite = new StringWriter();
//        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
 
//        /********************************************************************************/
//        //Try adding source strings for each image in content
//        string tempPostContent = getImage(HTMLCode);
//        /*********************************************************************************/
 
//        StringReader reader = new StringReader(tempPostContent);
 
//        //Create PDF document 
//        Document doc = new Document(PageSize.A4);
//        HTMLWorker parser = new HTMLWorker(doc);
//        PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("~") + "/App_Data/HTMLToPDF.pdf", 
 
//FileMode.Create));
//        doc.Open();
 
//        try
//        {
//            //Parse Html and dump the result in PDF file
//            parser.Parse(reader);
//        }
//        catch (Exception ex)
//        {
//            //Display parser errors in PDF. 
//            Paragraph paragraph = new Paragraph("Error!" + ex.Message);
//            Chunk text = paragraph.Chunks[0] as Chunk;
//            if (text != null)
//            {
//                text.Font.Color = BaseColor.RED;
//            }
//            doc.Add(paragraph);
//        }
//        finally
//        {
//            doc.Close();
//        }
//    }
 
//    public string getImage(string input)
//    {
//        if (input == null)
//            return string.Empty;
//        string tempInput = input;
//        string pattern = @"<img(.|\n)+?>";
//        string src = string.Empty;
//        HttpContext context = HttpContext.Current;
 
//        //Change the relative URL's to absolute URL's for an image, if any in the HTML code.
//        foreach (Match m in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | 
 
//RegexOptions.RightToLeft))
//        {
//            if (m.Success)
//            {
//                string tempM = m.Value;
//                string pattern1 = "src=[\'|\"](.+?)[\'|\"]";
//                Regex reImg = new Regex(pattern1, RegexOptions.IgnoreCase | RegexOptions.Multiline);
//                Match mImg = reImg.Match(m.Value);
 
//                if (mImg.Success)
//                {
//                    src = mImg.Value.ToLower().Replace("src=", "").Replace("\"", "");
 
//                    if (src.ToLower().Contains("http://") == false)
//                    {
//                        //Insert new URL in img tag
//                        src = "src=\"" + context.Request.Url.Scheme + "://" +
//                            context.Request.Url.Authority + src + "\"";
//                        try
//                        {
//                            tempM = tempM.Remove(mImg.Index, mImg.Length);
//                            tempM = tempM.Insert(mImg.Index, src);
 
//                            //insert new url img tag in whole html code
//                            tempInput = tempInput.Remove(m.Index, m.Length);
//                            tempInput = tempInput.Insert(m.Index, tempM);
//                        }
//                        catch (Exception e)
//                        {
 
//                        }
//                    }
//                }
//            }            
//        }
//        return tempInput;
//    }
 
//    string getSrc(string input)
//    {
//        string pattern = "src=[\'|\"](.+?)[\'|\"]";
//        System.Text.RegularExpressions.Regex reImg = new System.Text.RegularExpressions.Regex(pattern,
//            System.Text.RegularExpressions.RegexOptions.IgnoreCase | 
 
//System.Text.RegularExpressions.RegexOptions.Multiline);
//        System.Text.RegularExpressions.Match mImg = reImg.Match(input);
//        if (mImg.Success)
//        {
//            return mImg.Value.Replace("src=", "").Replace("\"", ""); ;
//        }
 
//        return string.Empty;
//    }
//}
 
//</img(.|\n)+?>