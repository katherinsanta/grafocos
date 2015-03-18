<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationPane.ascx.cs" Inherits="Servipunto.Cartera.Web.BlueSkin.UserControls.NavigationPane" %>
<!-- Navigation Pane -->
    <script type="text/javascript">
        
    	    BuildNavigationPane("<%=GroupID%>");
	    
    </script>
    <script runat="server">
    #region Local Variables Declaration
        private string _groupID = "";
        #endregion

        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            
        }
        #endregion

        #region Public Custom Properties
        public string GroupID
        {
            get
            {
                return this._groupID;
            }
            set
            {
                this._groupID = value;
            }
        }
        #endregion

   
    
    
    </script >
    
    
    
    
    <!-- End Navigation Pane -->