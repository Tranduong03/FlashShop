<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDetails.ascx.cs" Inherits="de1.UserControl.ucDetails" %>
<asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" DataSourceID="EntityDataSource1">
    
   
    <ItemTemplate>
            <div class="product_box">
    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
   <asp:Image ID="Image1" runat="server" Width ="100px" Height="100px" ImageUrl='<%# "~/images/Courses/" + Eval("ImageFilePath")%>' /><br />
    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
     
</div>

    </ItemTemplate>
</asp:FormView>
<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=QLKhoaHocEntities" DefaultContainerName="QLKhoaHocEntities" EnableFlattening="False" EntitySetName="Courses" Include="Category" Where="it.ID = @ID">
    <WhereParameters>
        <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32"/>
    </WhereParameters>
</asp:EntityDataSource>

