#pragma checksum "C:\Users\Admin\Desktop\intermediator-bot-sample-master\intermediator-bot-sample-master\IntermediatorBotSample\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2832bc51c936f56491a7557d2c4904e37fc1b92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Index.cshtml", typeof(AspNetCore.Pages_Index), null)]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 2 "C:\Users\Admin\Desktop\intermediator-bot-sample-master\intermediator-bot-sample-master\IntermediatorBotSample\Pages\Index.cshtml"
using IntermediatorBotSample.Pages;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2832bc51c936f56491a7557d2c4904e37fc1b92", @"/Pages/Index.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(66, 160, true);
            WriteLiteral("    <div style=\"background-color:blueviolet;\">\r\n        <h1>Agent User Bot Framework</h1>\r\n        <button onclick=\"CallBotApi();\"> Argha Guha Biswas</button>\r\n");
            EndContext();
            BeginContext(492, 368, true);
            WriteLiteral(@"
        <p>The bot endpoint URL is: <a id=""botEndpointUrl"" /></p>
        <script src=""http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"" type=""text/javascript""></script>
        <script>
    var botEndpointUrlLink = document.getElementById(""botEndpointUrl"");
    botEndpointUrlLink.setAttribute('href', location.protocol + ""//"" + location.host + """);
            EndContext();
            BeginContext(861, 21, false);
#line 18 "C:\Users\Admin\Desktop\intermediator-bot-sample-master\intermediator-bot-sample-master\IntermediatorBotSample\Pages\Index.cshtml"
                                                                                   Write(Model.BotEndpointPath);

#line default
#line hidden
            EndContext();
            BeginContext(882, 84, true);
            WriteLiteral("\");\r\n    botEndpointUrlLink.innerHTML = location.protocol + \"//\" + location.host + \"");
            EndContext();
            BeginContext(967, 21, false);
#line 19 "C:\Users\Admin\Desktop\intermediator-bot-sample-master\intermediator-bot-sample-master\IntermediatorBotSample\Pages\Index.cshtml"
                                                                          Write(Model.BotEndpointPath);

#line default
#line hidden
            EndContext();
            BeginContext(988, 25, true);
            WriteLiteral("\";\r\n        </script>\r\n\r\n");
            EndContext();
            BeginContext(1161, 1374, true);
            WriteLiteral(@"
        <script>
            $(document).ready(function() {
  $.post('http://localhost:3979/api/messages', {
    ""type"": ""message"",
    ""from"": {
      ""id"": ""user1""
    },
    ""text"": ""hello""
  }).fail(function(error) {
    debugger;
  }).done(function(response) {
    debugger;
  });
            });

              function CallBotApi() {

         $.ajax({
        type: ""POST"",
        url: ""http://localhost:29210/api/messages"",
        //data: '{conversationId: ""f34d48e0-37b8-11ea-8f71-014859054f51|livechat"",expires_in: 2147483647,streamUrl: """",token: ""http://localhost:3978/api/messages""}',
        data:'{""type"":""message"",""id"":""ghjjhjhvhj"",""timestamp"":""2020-10-19T20:17:52.2891902Z"",""serviceUrl"":""http:\/\/localhost:3978"",""channelId"":""arghaChannel"",""from"":{""id"":""argha guha biswas"",""name"":""Jeet""},""conversation"":{""id"":""f34d48e0-37b8-11ea-8f71-014859054f51|livechat"",""name"":""TestConversation""},""recipient"":{""id"":""12345678"",""name"":""banchodbot""},""text"":""Haircut on Saturday""}',
        content");
            WriteLiteral(@"Type: ""application/json; charset=utf-8"",
        dataType: ""json"",
        success: OnSuccess,
        failure: function(response) {
            alert(response.d);
        }
    });
}
function OnSuccess(response) {
    alert(response.d);
}
    var botAppIdItem = document.getElementById(""botAppId"");
    botAppIdItem.innerHTML = ""App ID: ");
            EndContext();
            BeginContext(2536, 14, false);
#line 62 "C:\Users\Admin\Desktop\intermediator-bot-sample-master\intermediator-bot-sample-master\IntermediatorBotSample\Pages\Index.cshtml"
                                 Write(Model.BotAppId);

#line default
#line hidden
            EndContext();
            BeginContext(2550, 127, true);
            WriteLiteral("\";\r\n    var botAppPasswordItem = document.getElementById(\"botAppPassword\");\r\n    botAppPasswordItem.innerHTML = \"App password: ");
            EndContext();
            BeginContext(2678, 20, false);
#line 64 "C:\Users\Admin\Desktop\intermediator-bot-sample-master\intermediator-bot-sample-master\IntermediatorBotSample\Pages\Index.cshtml"
                                             Write(Model.BotAppPassword);

#line default
#line hidden
            EndContext();
            BeginContext(2698, 33, true);
            WriteLiteral("\";\r\n        </script>\r\n    </div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
