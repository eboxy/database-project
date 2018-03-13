<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Gridview_grdResult_Artist.ascx.cs" Inherits="UserControls_Gridview_grdResult_Artist" %>


<!-- GridView för att visa resultat från Fetch (hämtad data för uppdatering) och sökning: -->



<asp:GridView ID="grdResult_Artist" runat="server" BackColor="White" AllowPaging="true" PageSize="6" 
      AllowSorting="false" OnRowCommand="gridResult_RowCommand_Artist" HeaderStyle-CssClass="header"
      OnPageIndexChanging="grdResultArtist_PageIndexChanging" AutoGenerateColumns="false"> 
              
     <RowStyle Height="35px" />                       
                                          

    <Columns>
                          
                             
      <asp:TemplateField HeaderText="Mark" ItemStyle-CssClass="grid_style" 
      HeaderStyle-CssClass="pos_gridartist">
         <HeaderTemplate>
                                        
            <TF:DerivCheckBox ID="chkArtval_ALL" runat="server" Checked='<%# Bind("ValArt")%>' AutoPostBack="true"
             UnText='<%#Eval("No") %>' OnCheckedChanged="chkArtvalALLGrdRes_CheckedChanged" />
                                        
        </HeaderTemplate>
                                        
        <ItemTemplate> 

           <TF:DerivCheckBox ID="chkArtval" runat="server" Checked='<%# Bind("ValArt")%>' AutoPostBack="true"
           UnText='<%#Eval("No") %>' OnCheckedChanged="chkArtval_CheckedChanged" />
                                         
       </ItemTemplate>
                                                
    </asp:TemplateField>
                                          
                                       
                                       
    <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
       <HeaderTemplate>
          <asp:LinkButton ID="lnkbtnNo" runat="server" CommandName="Sort" 
          ForeColor="#F7F7F7" CommandArgument="No" OnCommand="SortArtist_Command">
          ArtNo</asp:LinkButton>
      </HeaderTemplate>
      <ItemTemplate>
        <asp:Label ID="lblSortNo" runat="server" Text='<%# Eval("No") %>'
        EnableTheming="false">
        </asp:Label>                                      
     </ItemTemplate>
     <ItemStyle CssClass="grid_style" />             
  </asp:TemplateField> 
                                      
                                      
                                      
    <asp:TemplateField ItemStyle-CssClass="grid_style"
     SortExpression="Artist" HeaderStyle-CssClass="pos_gridartist">
       <HeaderTemplate>
         <asp:LinkButton ID="lnkbtnArtist" runat="server" CommandName="Sort" 
         ForeColor="#F7F7F7" CommandArgument="Artist" OnCommand="SortArtist_Command">
         Artist</asp:LinkButton>
      </HeaderTemplate>  
      <ItemTemplate>
      <asp:Button ID="Artist" runat="server" CssClass="arti" Text='<%#Eval("Artist") %>'
      CommandArgument='<%#Eval("No") %>' CommandName="Artist" />
      </ItemTemplate>        
      <ItemStyle CssClass="grid_style" />
   </asp:TemplateField>
                                       
                                       
     <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
       <HeaderTemplate>
          <asp:LinkButton ID="lnkbtnVPfr" runat="server" CommandName="Sort" 
          ForeColor="#F7F7F7" CommandArgument="VPfr" OnCommand="SortArtist_Command">
          VPfr</asp:LinkButton>
       </HeaderTemplate>
       <ItemTemplate>
          <asp:Label ID="lblSortVPfr" runat="server" Text='<%# Eval("VPfr") %>'
          EnableTheming="false">
          </asp:Label>                                      
      </ItemTemplate>
      <ItemStyle CssClass="grid_style" />             
   </asp:TemplateField> 
                                       
                                       
                                       
   <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
      <HeaderTemplate>
         <asp:LinkButton ID="lnkbtnVPtill" runat="server" CommandName="Sort" 
          ForeColor="#F7F7F7" CommandArgument="VPtill" OnCommand="SortArtist_Command">
          VPtill</asp:LinkButton>
       </HeaderTemplate>
       <ItemTemplate>
          <asp:Label ID="lblSortVPtill" runat="server" Text='<%# Eval("VPtill") %>'
          EnableTheming="false">
         </asp:Label>                                      
      </ItemTemplate>
      <ItemStyle CssClass="grid_style" />             
  </asp:TemplateField> 
                                       
                                       
   <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
      <HeaderTemplate>
         <asp:LinkButton ID="lnkbtnUrsland" runat="server" CommandName="Sort" 
         ForeColor="#F7F7F7" CommandArgument="Ursland" OnCommand="SortArtist_Command">
         Ursland</asp:LinkButton>
     </HeaderTemplate>
     <ItemTemplate>
       <asp:Label ID="lblSortUrsland" runat="server" Text='<%# Eval("Ursland") %>'
       EnableTheming="false">
       </asp:Label>                                      
    </ItemTemplate>
    <ItemStyle CssClass="grid_style" />             
 </asp:TemplateField> 
                                       
                                       
  <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
     <HeaderTemplate>
        <asp:LinkButton ID="lnkbtnUrsstad" runat="server" CommandName="Sort" 
         ForeColor="#F7F7F7" CommandArgument="Ursstad" OnCommand="SortArtist_Command">
         Ursstad</asp:LinkButton>
     </HeaderTemplate>
     <ItemTemplate>
       <asp:Label ID="lblSortUrsstad" runat="server" Text='<%# Eval("Ursstad") %>'
       EnableTheming="false">
       </asp:Label>                                      
    </ItemTemplate>
    <ItemStyle CssClass="grid_style" />             
 </asp:TemplateField> 
                                       
                                       
  <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
    <HeaderTemplate>
       <asp:LinkButton ID="lnkbtnMusiktyp" runat="server" CommandName="Sort" 
       ForeColor="#F7F7F7" CommandArgument="Musiktyp" OnCommand="SortArtist_Command">
       Musiktyp</asp:LinkButton>
    </HeaderTemplate>
    <ItemTemplate>
       <asp:Label ID="lblSortMusiktyp" runat="server" Text='<%# Eval("Musiktyp") %>'
       EnableTheming="false">
       </asp:Label>                                      
    </ItemTemplate>
    <ItemStyle CssClass="grid_style" />             
</asp:TemplateField> 
                                       
                                       
                                       
   </Columns>
                        
</asp:GridView> 
                        
                       











