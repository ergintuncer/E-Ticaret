<%@ Page Title="Tüm Kişiler" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="kisiler.aspx.cs" Inherits="Admin_kisiler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="pageDisDiv">
        <div class="altDiv">
            <asp:ListView ID="list2" runat="server">
                <ItemTemplate>
                    <div class="ListeDiv">
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server" Font-Bold="True">Ad Soyad: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblpaylasimHeaderAdi" CssClass="lblpaylasimHeaderAdi" runat="server" Text='<%#Eval("ad_soyad") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server" Font-Bold="True">Kimlik No: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="TcKimlikNo" CssClass="kisiBilgi" runat="server" Text='<%#Eval("tck") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server" Font-Bold="True">Firma Bilgisi: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="firma" CssClass="kisiBilgi" runat="server" Text='<%#Eval("firma") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server" Font-Bold="True">Baro Adı: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="baroBilgi" CssClass="kisiBilgi" runat="server" Text='<%#Eval("baroad") %>'></asp:Label>
                            </div>
                        </div>


                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server" Font-Bold="True">Sicil No:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="sicilNo" CssClass="kisiBilgi" runat="server" Text='<%#Eval("sicilno") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server" Font-Bold="True">Birlik Sicil No:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="birlikSicilNumarası" CssClass="kisiBilgi" runat="server" Text='<%#Eval("birliksicilno") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="lineOrtaSol">
                            <a href="kisiler.aspx?islem=bloke&kisiid=<%#Eval("kisiid") %>"><img src="/image/cancel.png"/></a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    
    
    
    

    
</asp:Content>