<%@ Page Title="Mahkeme İşlemleri" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="mahkeme.aspx.cs" Inherits="Admin_Mahkeme" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="pageDisDiv">
        <div class="ustDiv">
             <div class="alert alert-danger" role="alert">
 <asp:Label CssClass="label" ID="lblMesaj" runat="server" Text="" visible="false"></asp:Label>
</div>
            <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
                <asp:Label CssClass="label" runat="server" Text="Yeni Mahkeme Oluştur" Font-Size="200%">Yeni Mahkeme Oluştur</asp:Label>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server" Font-Bold="True">Adı: </asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtMahkemeAdi" CssClass="TexBoxCss" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Adliye:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpAdliye" CssClass="drplist" runat="server"></asp:DropDownList>
                </div>
            </div>
           
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Aktif:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:CheckBox ID="ctxAktif" runat="server"/>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Mahkeme Türü:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpMahkemeTuru" CssClass="drplist" runat="server"></asp:DropDownList>
                </div>
            </div>
         
            <div class="line">
                <%-- Bu divi silme. Ortalama yapması için konuldu--%>
            </div>
            <div class="lineOrta">
                <button runat="server" id="btnKaydet" onserverclick="btnKaydet_Onclick" class="button" title="Adliye Bilgisini Kaydet">
                    <i class="fa fa-floppy-o fa-2x"></i>Kaydet
                </button>
            </div>

        </div>


        <div class="altDiv">
            <asp:ListView ID="list2" runat="server">
                <ItemTemplate>
                    <div class="ListeDiv">
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Mahkeme Adı: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblMahkemeAdi" CssClass="il" runat="server" Text='<%#Eval("mahkemead") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Mahkeme Türü: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblMahkemeTuru" runat="server" Text='<%#Eval("mahkemeturad") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Adliye Adı: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblAdliye" runat="server" Text='<%#Eval("adliyead") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Aktif: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="Label2" CssClass="lblaktif" runat="server" Text='<%#Eval("aktif") %>'></asp:Label>
                            </div>
                        </div>
                        
                       
                       <div class="lineOrtaSol">
                            <a href="mahkeme.aspx?islem=aktif&mahkemeid=<%#Eval("mahkemeid") %>"> <img src="/image/cancel.png" /> </a>
                          
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    
    
    
    
    
    

  


</asp:Content>