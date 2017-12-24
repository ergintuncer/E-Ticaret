<%@ Page Title="Baro İşlemleri" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="baro.aspx.cs" Inherits="Admin_Baro" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="/CssDosyalari/adminbarod.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="MainScriptManager" runat="server"/>
<asp:UpdatePanel ID="pnlHelloWorld" runat="server">
<ContentTemplate>
    <div class="pageDisDiv">
        <div class="ustDiv">
            <%-- <div class="alert alert-danger" role="alert">
 <asp:Label CssClass="label" ID="lblMesaj" runat="server" Text="" visible="false"></asp:Label>
</div>--%>
            <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
                <asp:Label CssClass="label" runat="server" Text="Yeni Oluştur" Font-Size="200%">Yeni Baro Oluştur</asp:Label>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Baro Adı:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <%--<asp:TextBox ID="txtbaroadi" CssClass="TexBoxCss"  AutoPostBack="true" runat="server"></asp:TextBox>--%>
                    <asp:TextBox ID="txtbaroadi" CssClass="TexBoxCss" OnTextChanged="txtbaroadi_TextChanged" AutoPostBack="True" runat="server"></asp:TextBox>
                     <br/> 
                        <asp:Label ID="lblOnTextChanged" runat="server" Visible="False" ForeColor="#F50057" ></asp:Label>
                </div>
            </div>
           
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Aktif:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:CheckBox ID="CheckBox1" runat="server"/>
                </div>
            </div>
            <div class="lineOrta">
                <button runat="server" id="bynBaroKaydet" onserverclick="btnKaydet_Onclick" class="button" title="Baro Bilgisini Kaydet">
                    <i class="fa fa-floppy-o fa-2x"></i>Kaydet
                </button>
               <%-- <button runat="server" id="bynBaroKaydet" class="btn btn-warning" onserverclick="btnKaydet_Click" text="Kaydet">
                    Kaydet
                </button>--%>

            </div>
            <div class="alert alert-success alert-dismissible fade show" role="alert" id="successalert" runat="server" Visible="False">
               
                <asp:Label ID="lblacik" CssClass="label" runat="server" Font-Bold="True"> Değişiklik Gerçekleştirildi... </asp:Label>

                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="alert alert-danger alert-dismissible fade show" role="alert" id="dangeralert" runat="server" Visible="False">
                Hay aksi. Bir hata oluştu.
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
        </div>
        
        

        <div class="altDiv">
            <asp:ListView ID="list2" runat="server">
                <ItemTemplate>
                    <div class="ListeDiv">
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server" Font-Bold="True">Baro Adı: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblBaroAdi" runat="server" Text='<%#Eval("baroad") %>'></asp:Label>

                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server" Font-Bold="True">Aktif: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblAdktif" runat="server" Text='<%#Eval("aktif") %>'></asp:Label>
                            </div>
                        </div>
                       
                        <div class="lineOrtaSol">
                            <a href="baro.aspx?islem=aktif&baroid=<%#Eval("baroid") %>"> <img src="/image/shuffle.png" /> </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    
    
    
    
    
    
    </ContentTemplate>
</asp:UpdatePanel>
    
    

    
</asp:Content>