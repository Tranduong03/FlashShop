<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultPageMaster.Master" AutoEventWireup="true" CodeBehind="ManageCourse.aspx.cs" Inherits="de1.ManageCourse" %>

<%@ Register Src="~/UserControl/ucManageCourse.ascx" TagPrefix="uc1" TagName="ucManageCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucManageCourse runat="server" id="ucManageCourse" />
</asp:Content>
