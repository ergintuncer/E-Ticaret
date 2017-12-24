<%@ Page Title="Adliye İşlemleri" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="adliye.aspx.cs" Inherits="Admin_Adliye" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pageDisDiv">
        <div class="ustDiv">
           <%-- <div class="alert alert-danger" role="alert">
 <asp:Label CssClass="label" ID="lblMesaj" runat="server" Text="" visible="false"></asp:Label>
</div>--%>
            <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
                <asp:Label CssClass="label" runat="server" Text="Yeni Adliye Oluştur" Font-Size="200%">Yeni Adliye Oluştur</asp:Label>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server" Font-Bold="True">Adı: </asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtadliyeadi" CssClass="TexBoxCss" runat="server" OnTextChanged="txtadliyeadi_OnTextChanged" AutoPostBack="True" ></asp:TextBox>
                    <br/> 
                    <asp:Label ID="lblOnTextChanged" runat="server" Visible="False" ForeColor="#F50057" ></asp:Label>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">İl:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpil" CssClass="drplist" runat="server" OnTextChanged="drpil_OnTextChanged" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>
           
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Adres Adı:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtadresadi" CssClass="TexBoxCss" runat="server"></asp:TextBox>
                </div>
            </div>
           
          
           
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">İlçe:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpilce" CssClass="drplist" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Adres:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtadres" runat="server" CssClass="TextBoxCssMulti" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Açıklama:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtaciklama" CssClass="TextBoxCssMulti" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Aktif:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:CheckBox ID="ctxAktif" runat="server" Text="Aktif"/>
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
                                <asp:Label CssClass="label" runat="server">Adliye Adı: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblpaylasimHeaderAdi" CssClass="lblpaylasimHeaderAdi" runat="server" Text='<%#Eval("adliyead") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">İl: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblil" CssClass="il" runat="server" Text='<%#Eval("ilad") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">İlçe: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblilce" CssClass="lblilce" runat="server" Text='<%#Eval("ilcead") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Adres Adı: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lbladresadi" CssClass="lbladresadi" runat="server" Text='<%#Eval("adliyeadresad") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Adres: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lbladres" CssClass="lbladres" runat="server" Text='<%#Eval("adres") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Açıklama: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="Label1" CssClass="lblaciklama" runat="server" Text='<%#Eval("aciklama") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Aktif: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblaktif" CssClass="lblaktif" runat="server" Text='<%#Eval("aktif") %>'></asp:Label>
                            </div>
                        </div>
                       
                       
                        <div class="lineOrtaSol">
                            <a href="adliye.aspx?islem=bloke&kisiid=<%#Eval("adliyeid") %>"> <img src="/image/shuffle.png"/></a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>


</asp:Content>