﻿namespace MyTested.HttpServer.Samples
{
    using AngleSharp.Parser.Html;
    using MyTested.HttpServer;
    using System.Linq;
    using System.Net.Http;
    using Xunit;

    public class HtmlTests
    {
        private const string BaseAddress = "https://mytestedasp.net";

        IServerBuilder httpServer;

        public HtmlTests()
        {
            httpServer = MyHttpServer.WorkingRemotely(BaseAddress);
        }

        [Fact]
        public void HtmlShouldContainMyTestedHttpServerTitle()
        {
            httpServer
                .WithHttpRequestMessage(req => req.WithMethod(HttpMethod.Get))
                .ShouldReturnHttpResponseMessage()
                .WithContent(html =>
                {
                    var parser = new HtmlParser();
                    var document = parser.Parse(html);

                    var element = document
                        .QuerySelectorAll("h4.content-title")
                        .FirstOrDefault(el => el.InnerHtml.Contains("My Tested Http Server"));

                    Assert.NotNull(element);
                });
        }

        [Fact]
        public void HtmlShouldContainContactForm()
        {
            httpServer
                .WithHttpRequestMessage(req => req.WithMethod(HttpMethod.Get))
                .ShouldReturnHttpResponseMessage()
                .WithContent(html =>
                {
                    var parser = new HtmlParser();
                    var document = parser.Parse(html);

                    var element = document
                        .QuerySelectorAll("form#contact-form")
                        .FirstOrDefault();

                    Assert.NotNull(element);
                });
        }
    }
}
