<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCoureList.ascx.cs" Inherits="de1.UserControl.ucCoureList" %>
<asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="EntityDataSource1">
    
    <ItemTemplate>
        <div class="product_box">
        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
       <asp:Image ID="Image1" runat="server" Width ="100px" Height="100px" ImageUrl='<%# "~/images/Courses/" + Eval("ImageFilePath")%>' /><br />
        <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
          <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"~/Details.aspx?ID="+Eval("ID") %>' runat="server" CssClass="product_view">View Details</asp:HyperLink>
    </div>
        </ItemTemplate>
    
</asp:ListView>
<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=QLKhoaHocEntities" DefaultContainerName="QLKhoaHocEntities" EnableFlattening="False" EntitySetName="Courses" EntityTypeFilter="Course" Include="Category" Where="it.CatID = @ID">
    <WhereParameters>
        <asp:QueryStringParameter Name="ID" QueryStringField="CatID" Type="Int32"/>
    </WhereParameters>
</asp:EntityDataSource>

