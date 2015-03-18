using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Servipunto.Cartera.Web.BlueSkin.UserControls
{
    public partial class TopicHeader : System.Web.UI.UserControl
    {
        #region Local Variables Declaration
        private string _topicID = "";
        private string _title = "";
        private string _shortDescription = "";
        private string _image = "";
        #endregion

        #region Page Load Event
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
        }
        #endregion        

        #region Public Custom Properties
        public string TopicID
        {
            get { return this._topicID; }
            set { this._topicID = value; }
        }

        public string Title
        {
            get
            {
                if (this._title.Length == 0)
                    return "Please write your topic title.";
                else
                    return this._title;
            }
            set { this._title = value; }
        }

        public string ImagenT
        {
            get
            {
                if (this._image.Length == 0)
                    return @"../../BlueSkin/Icons/TopicDefaultImage.gif";
                else if (this._image.IndexOf("/") == -1)
                    return @"../../BlueSkin/Icons/" + this._image;
                else
                    return this._image;
            }
            set { this._image = value; }
        }

        public string ShortDescription
        {
            get
            {
                if (this._shortDescription.Length == 0)
                    return "Please write your short description.";
                else
                    return this._shortDescription;
            }
            set { this._shortDescription = value; }
        }
        #endregion
    }
}