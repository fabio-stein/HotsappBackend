// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// WebhookList.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7xWUW/bNhB+3684qHuIC1nuw9p1eQvQAi0WLEHibA+GMZ2ps8WZIhXyFE8Y+t+HoyTXstt12AI/2fzII7/vPt5RfyXztqbkMvmNVqVzWzA6cJImv6LXuDL0C1Yym6TJz9R+HryjoLyuWTubXCbXOjC4Ney6PUKWpMmV99h2e79KkzvC4saaNrlcowkkwGOjPRV74Na7mjxrCsnl4pjVKaHhqBGxA3BM8MoCCp9/IPnmv5N8/0SWIQ5OeJLM/c5tTWOqY/zrbJsa2AGThRgRZLQrtSrlT2hWErciaF3jB2UZzA+n2AEaM4Rrq0xTaLsBS7sBxABcUgvoCbAoqEgh1KT0uhUcMDB5HbZwkb/MJ7DTpgCFvogHeaoNKooL8wNVeadhvFP+Mj8Kl+sW+YWmrp1nKnpSKSy6uSfURhLa48uLF3toGqGpnJfJ4snzeRrYa7s59bM4cOrQzzF+5CeUTYV26gmLqORgsXgsmYlK/m/d2MaYT+k3NVj5OSTfA2PW85Kgsfqx6cmBrDoTw8DIzbhg9tApy25KMolDDTxjPpf/gq8uRlzj8JTnx3eD20OlPm82r7XdwsGxcLP6g9QXurnR9qhzDsjXG5Gnx4YCTz0ZlCpdfLiav7+5uocYuryYFU6FGdZ6ViKTwzCNE7Mz1GTpaT1S0wOnDihX1YaYgNFviOHh7jp2oQq3XQcb1Ck0JpXlK227mYq4dAXsNJfApQ5RdwrawuLh7iMwVbWEwtr5Cnl5UTLX4XI2Y+dMyDTxOnN+Myu5MjO/Vm9e//hqksHH2I777vl9nkJ+kaeAtoB8koMq0aNi8kG2hdrTtPZOUQjabjIQRblozUHHDg5bamHwRbQ6K4XLJXJnE+A+BZ3GTg/G50IMthzhM5V5l9ORdXvo1LwP8/ntYIPvT5fX7YvmnUmBJzOi341PuS8k/R1BKUx5sb55RV7/9Pbti0BKIqY/TNL+3Q/knyi+2WilpcjNwGhvZ3RjsVrpTeOaYNr+qVlRdz8CVWhZqzA0IgnL4J4IFrF73PUMw2d2u90u02gxcsMQ9MZW8hDPJHY6SDoeZn+KjMnZOnDjx0Z041MjHu6uuzTpAMrZtd40/TWSDwiy4Czkxik0pQucx+xqq1wln0z57c39PAfrWK+16qysKATcxPwiy5aMuv9YA227bqCdfaZELD999zcAAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Webhooks
{
    /// <summary>
    /// List of webhooks.
    /// </summary>
    [DataContract]
    public class WebhookList
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public WebhookList() {}

        /// <summary>
        /// An array of webhooks.
        /// </summary>
        [DataMember(Name="webhooks", EmitDefaultValue = false)]
        public List<Webhook> Webhooks;
    }
}

