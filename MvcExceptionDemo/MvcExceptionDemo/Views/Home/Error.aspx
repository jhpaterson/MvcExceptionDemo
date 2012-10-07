<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.HandleErrorInfo>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Error
</asp:Content>

<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Something bad happened - we're on the case!
    </h2>
    <p>
      Controller: <%=((HandleErrorInfo)ViewData.Model).ControllerName %>
    </p>
    <p>
      Action: <%=((HandleErrorInfo)ViewData.Model).ActionName %>
    </p>
    <p>
      Type: <%=((HandleErrorInfo)ViewData.Model).Exception.GetType().FullName %>
    </p>
    <p>
      Message: <%=((HandleErrorInfo)ViewData.Model).Exception.Message %>
    </p>
    <p>
      Stack Trace: <%=((HandleErrorInfo)ViewData.Model).Exception.StackTrace %>
    </p>
</asp:Content>
