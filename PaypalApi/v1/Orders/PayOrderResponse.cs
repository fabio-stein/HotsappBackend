// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PayOrderResponse.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+w92XIbOZLv+xUZ6o0Yy8FDko+e9pssu90at1sKHdOxoXWQYFWSRAsEygBKMr0xEfsb+3v7JRs46i7KpERVa2bxohATmSiceSKB/9q5WCa482bnlCzhRMYo4QxVIrjCnd7O34mkZMLwN7IwODu9nY+4LH68QxVJmmgq+M6bnUNIyBKErUP6OgY7vZ1DKcnSfWWvt3OGJD7hbLnzZkqYQgP4klKJcQ44lSJBqSmqnTdXefuUlpTPmm2KJBKNI00XWGleFV5t6cUcISYagfAYDAbczpGDnqNpuEhlhHBLFLg64h5QDlfHXKPkqGuUUyEXRH9+Ntc6UW+GQy0EUwOKejoQcjac6wUbymn04sWLn35QGJkW9F8NXu8+dGR4ytg/et8dHso1cl0ZmRzUHBRXtOWm/Ur5NZS+BSeTPzDSzbYyyq9VpakZpLbQOBDTPBBTkPglRaX7EpmZKrj65fDi/cnhOVjSz8+GsYjUkCR0KG5Q3lC8Hf4wJxoFUX2LUp+I19tfonOJ00q3PKA5/pFYJAw1giZyhhouz34dwIWABblGvzxdNyPCWM+gTyh3JQvUcxHDLdVz0HOq7AC4lXt5dgwaF4khXXe9vn71497uAI55xNLYfWH87+MejJ+Ne3bxj3fHEM2JJJFGqUy1kEjsJ1JEqBTlswGYHo1NX8dAla3iGpeQTZDpq+DINeg50W6+gORD4Pro+kNApRNlZpprC+5o87gxrUxdDmpO3i8XF6fZNEj/ddArJq+jHkhklea73822X5nhdw00O1QvE/zuEnn101//mrO0l7s9uJ3TaA4K5Q0qIAoIh+N3dmUQO71uolNOFhM6S0Wq2BJi25QJuvWhcEG4ppEyW9sADNkAzhHhyrKRM99CVbTu9vZ2QAkntm1EKTrjC+RaDQ1tP+tS/efgq+nGdrjw5zUmworFEa0uphKwOSXH77JBsGhbXjCnZIkSjrljB+arjSYnBmVE+VRUGl0BN5tti4EWFW9PBTiMY4lKNVs6oYxRPhuRHKFobrOs2WaPAx7HME1iOmLW0QCOCIcJAn7VyGOM7YJWc5okJZIO9Byql1UFxwFahAjVS+BkgR3xmEikXMvlKBJxTQWrFtS1xSt9K/q5CIHj8xN4sf/6dX8fDEEmuo1KMpN2JQ1jKjHSQ4lKD33lfYOrhruOt9AYuaZT6tmJxwFhFNKZWYv/me7tvYgmTETXX1Kh0f52fyOlpeAzB/lNaHzjwMMyHC5K1ZpP29XwweiJ8FZSTSg3ss5RmnJH9uGtr6sAWSHKhW7gXn5swVWQKozNwjT90iLpM7xBBrFYmE+a2XYy2A6Db+AALpUX3UcH42azj+aUE7gVksW31MOM+CXSzC6kPBJcS8EYxpBIGiE8O7o83fUyrgcTwq8hIjJ2GkEkhVL9iTMAtCRckcjxWt+h+rBvsjy1TO+3OhnluF9XKi2kuXOmVCqriWDGerPtDT8LCfiVGN2kBzxdTFD2QGmJqF3vlYANed2DunTQ6NJBo0sn9h/CnCamMBI8XqN3KqUae0ASIrXhgHl379fN+zMWbkQIo9/s5h8pTXRa5e0rEJoTmzH2CgE4ggGcoU4lxxgEZ0unyRohpmAqxQLeSvKNdqWvJXPBq0w0g7RIWlOST45R9N8P9g9eNDR8qyDpdEC5YZ3R8KJ/9v6ob3H7B3t7+3sH/eMh8t0BfCJf6SJdAEM+03PDyF7tlZT8rsZAKE1YU5xU4S3jYcste8t0UW92fKOJ43pmmX9J6Q1hVrJfLBNqlPFloa87HmgYpREi3voo1WyqILxSi9VOTwuUYuSRD27pNU0wpk49Nb+Gp0U/uvICmJVeHcwM0mIKrCN9LXkue52Kf3lud5QdIjPqxRhZBKHnWBpbs+1KY16WF0Ar7MnMIuUgcr6lsKjmDVwdypmR+pxs0ugfSEa124Mrt8c3op9YEkN8RDiJN/t4ZEkM8TGP6Wa01FBYUk3YcjNSQ2FI/0YSwjci/cNQGNJP+JVGYiPahSUxxBdzQhnh8Ubk2hPt9szKurrk1BjR5wZFbVRRqkgrk3u5B4ryGcP+ZKmxe4bXItnWkGVeenXTRG2Kyw30gGbzTIHZp+26xfiXk0/vRydno99Pzj6OezD+cPzzxXjbqsU6BvmESj0fxXW+WAG3WYpSz50H2OtQVlVo8xDf2zFcG7H9n37a6++97O8fjJ+0QZcb/39RTdNur5+bdoURsqGJ11HvcUFo1WmWQVb312IUS77JYvYPfuyer1hzZmRsw0p3KuDVfXLGUId+BEbaWluGrm6sweqyrQsaxwybra3CV7fX4XXZYu+2i9t8ee0OyFOyPCWs71yqGAPySC4TI3udj+/43VM0ivwAl42jtg158GcYNqZNo4YorYBXmXmmuCt1hLBUZz7hkkpSBq8e+AJty809z1yuK93AmVO21Q/cUtjsRN2tCzFqQllw7wb3bnDvBvducO8G925w7wb37lNz70qMaEKRt5hPjaLmwJqCjGXk6EC0O0a0pQB3cFQHR3VwVAdHdXBUb+qoVul0Sr9WBz0D3WGGW5SuBp18rXuWctCKJv7vf/+PAk2+wvG7AZynSSKkzjhs7nvKzmBlpyqNAtdpl5rOmir8+51zjpvue1heWaepjOZEIRiO1KKQ+eJRyqmu7u5G0eqD2BkqWNQBvCfR3P4PqDSZMKrm6M73cm24FkxQ3yL6k3Yo7c4y/+H2DmQfLoz0bfaYZPCipzmodUrtFDmUntMau3MMpVIij2rOoQLYohfpuUSsul76Lw/2f4SMbD0PjEfOwy/Zko0FKuvaUG5RA2Esq9roS1s1kk/94LuphHdu2JvDFOcFxSgVsFbhRJ35nE0lkIlIdRbTK83448/xjE716FaSpNL8MrTZAVMKphSmiK0hp7Jtl1tM7jy/8s6vlJU9ZIy6X+d4gxxiOqNawQSnQjo3U4wRXRieJSjXmdcnI6pWcbEh+q3IvkemZsmu+blh1oFuhMKc8NgeJp5iVSrUCpqzlSGEyTJNfnrinnKVSsIjrGVKFdC2ZClfGia1Mqm5m23lzHZlrvhoTmsc6O74T5jRrnhqHpeLqYoaallb6d3TBhlm2JFPj82qdKKFJqxmzebAlqn1hV4Xy7tCNS7UAI4zt6XNAs2n0oVBLE7PuTET19ilWQXPn2f+4OfPwy7vypyum9HtThnyNcxIR46l5k5cvQ0re9BMxczltmYnIBEmy+I4pPOlSZymPFY9kJhIVMi1C9f4Wmwou6D32FmlQtIZ5Y5ZtZ/gCWtiM5t6nSURpUqLRc3V4EEtJ1EYRa77iRQ3NMbYZkhKM2fH7+zZBLtCJEaCR5Rl6NUAivWleLFUOVNQRG0pL5c4ByxqzdDKMIlGxqkBmMHIPBLfE3kdSbu4NGJVv0QZ3uJwylxpJcTO7KAbQSMcubBzzRiqFbV5yqTmKFtWhCf24Ww/O1T51OY/c/KONS5axsGoDtXue8hqD6hTSR79Nomn4xB82rvITEdlB8ETNFEb8fqVUXrbHXvs76kcL7dnxqrhAg9Z0fpIqGCVdTM3X1LCdf1IaQm4YoYyjO/OUlf24nVaNRXt7xYrUYvoGq4RrRfARp2enX+83K2Yi4OnZerYAbf2zhPkS6msWgbud7MTl2e/GiXP9qV85wcc3hDK7DnTkpUg8xOuJYVuTpUWcvtRzwVqEhNNWq/1yUoqF/tkwGo3P/mC7YWBzBetHvt3wlIzz1S2H5ObkOh61GhpvWS1RmLERZ/wuH9jP5QQKlV2hJjbw8y5gmbq6oFKo7k/jSx79i9MEWPztR6oSEhcfQLiEVSd9aXjNRb7pqXXA/gPkcIiVabn0t3DZHEdij2rbSZFLxPsirfZT1d6l0Ga3XPNvKuD2949a61Ro7E7O4zIZXOhthY/ZLWaKoqznJNlxiJr5/KgdAlZWKP/amv081pHyzWdLkd1KVYBrz7oYdFo5C4Ks3fwbfvuLWsmw8+Iqw80eFt6NEUctR1uaC9faZPb0IhLolEQCcYwKlvaubuttI22J/COCuv0QSdxJkRhYbMKe42kO9PLGEwpJzyihLmVmN8IOaXI4vrxvglhhEfYy+c8TnF7iR7rG/FHjaSqf5WTPd0wnexMVpoYPfP5b89XG2cKEyKJFrJnNJwYp9R7F6+yUdx03PLdQ5JEikRSw7ErMzHYst/2lCwRW8//I72p+etKwPZjigi3c+ufNWjONe9c8GYbTFM2pYype15AeJ89sUnifSXhHohSIqJ2t/v7T30P/6KypU0iHxT2EcPCRVmpibr1X6+Q8GWtol4pdBER7iw3P5YZ6u+EMdQZi1EDeGcXE0QSY6ptal1eCESapcopxoYXmdVsy+11qNSeMvGKj6urqwtQZTQnXNdP91bhLdOTp4pXRy27DzQfu0e41RLhHVUJI0v4tNICtN8exQ5v1GoPrkRpuUraIfXtGsgwt9vP7++eiSQ8bub/VMCrj4tPUkW5TaHbfmJxNh2nPtWt7t/1Q9zMjauXrGBj9Wz/xz+Se+/7Uda9FyXLMIvxBplp2iAhy4SwQSQWm+VNl26pMQOVpQ535N1uRpHuiB5R3s9GoTX38fVLD6F8BgkjfP1UyNcv+wd7+3v7+/3j7q78vb88K7MO2ZG//3PNtFqhaiQeXGOUf4qSca/NG7SMoGUELSNoGUHLCFpG0DL+DC1jrbvKjPwZZac3hKwzzWbxandugQbChR8n6RJlRUDa9GuLLaa5GCGRpjdUb3sd202FcnW3GeXXGI9mUqRJa8drCI2QyvE75+q1CAoWKdM0Ye41DYwbqZqVM2eV43lGXfBEldB0niDnLzma5sc9B3Do/wN36jpCperkKsGITmlUCdoYFciHhxVZ5N+1fdi+ALfNP08XCyKXq2dC5QjNSSjKVi89j7M9YXFOWItwI6meC+nvvamGCRpFq+NvVVR/V0ZlrZjJrQCsUjonNwjfUAoQEhZCYq2mkM8b8nlDPm/I5w35vCHRLOTzhnzekM8b8nlDPm/I5w35vCGfN8xIyOcNa+Lx8nnD4+h3WgnVeON3H+JVhOE2T8iGh9LDQ+nhofTwUHp4KP2+dwy7oo748+o0htI3G77EZtk/S2LDg+IbIbMhZDZsQYNNk7hVg63C76fB2kfjXEVPWI0tj9IRSXQqWyLAkSuo8s0ScLVemCE9JN6b1REivSHSGyK9IdIbIr0hBBEivSHSGyK9IdIbIr0h0hsivSHSG2YkRHrDmng0P9mmoUzvsgnRzBDNDNHMEM0M0czHkdQSiRK8mcNbhdf4HLhS9yC1u7ONxzQi2g+XL84U6nISnX/XeArjBHlM+WwMQsJY4g1KhfH4ST4Umze6G8EUwrghjBvCuNsM45Y54Zm1Bto4obUSalwwg92l6Tnr4gHhSV9FiE6G6GSIToboZIhOBrd5iE6G6GSIToboZIhOhuhkiE6G6GSYkRCdDGvi8fJQnVO3fsFrBbxJ4qV7WNbeN/c0M0X9FXhlJ3bbUnvEVxtD+DWEX0P4NYRf/38nkxLWEDoF7ElLnIfkwW6xoeVRbr981IyUaozw3fLDYjwkpGMrCAGdENAJAZ0Q0AkBneBpDAGdENAJAZ0Q0AkBnRDQCQGdENAJMxICOmFNhItFw8WiIRYUYkEhFhRiQeFi0XCxaMhICxlp4WLRcLHoBm+x3ieD+aJIUrY5zE4AbZSnDO9vkOuUMLb0jhnLleCWMmbsREYizIlH7mPjAZghyLbi9/xZnSkAUzTLu3EQoVbQHMLs/fPKe+aVaPl2e3CeeUcP3QvBd/hgSY7R4oItCu/wwGavEHcXH6e6Fht3gBYbgOrlYzxRvt2Xvg+b73yfQP7O9xoirfaGt7toIEau6ZR6bTB7Kds6aWZG8XHuhgkT0fWXVGgsOyGUloLPHOQ3odH7VoZlOFyUqs2Zwwdj8sNbSTWh3JgqjtKUO7IPb31dBSh/fLiOe/mxBVdBqpzsslcmiKTP8AaN/F6YT5rZzl7EJjp/wBwulbe8jg7GzWYfzSkncCski2+phxnriUgzu5DySHAtBWMYQyJphPDs6PJ01/Mfo1Pxa/v+tFOkIimU6k+EjI0cLr3DnPl86sO+1QMUq1Ynoxz36z4BC2nunCmVSjufutec/TavKZPZm+tKS0R9XzXyQV06aHTpoNGlk8Sd/HCGtMJI8HiN3qmUaqMbJ0RqK2+y7m5NW173ZXyjXjD/DvOoxQBagdB6CsZy6wqBN5IGcIY6lbwc0bXOWAVTKRbwVpJvtCtz277pX32v20Nazmu1vf9/8GL9B/8PXvQP9vb29w76x0Pku23O51d7j3fEe+UYCKUJa4qTKrxlPGy5ZW+5m9zJgW80cVzPLPMvKb0hDLkewMUyoZHR0Qp3i+OBhlEaIeKdR6WaTRWEV2qxzoXTAqUYeeSDW3pNE4yp8y6YX8PToh+7nSlxEU0ocj0ykqKmxtWKmgNrCoqzmR4dbFSDqpyJdHeuFBtekPZ2X62jR1jyin1H4PI80/Cd1lrMtkUQeo6lVWIYSGn1lCUf0AqjNeuRchA5B1ZYVPMGrg7lzOgvnGzS6B9IRrXbgyvHrTain1gSQ3xEOIk3+3hkSQzxMY/pZrTUUFhSTdhyM1JDYUj/RhLCNyL9w1AY0k/4lUZiI9qFJTHEF3NCGeHxRuTaE+32zMq6uuTUWHnnBkVtVFGqSCu7frkHivIZw/5kqbF71r2ZkzLbFV4OdxShN8UVP6QDtMSCl4ndp+1a0viXk0/vRydno99Pzj6OezD+cPzzxXjbStLnTU4WtUQbmmV32LTer1Dr5+X56fkpkRGyp3n9WsMv80/hkrdWUkfjGXyFn//xb/8HAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// A pay order response.
    /// </summary>
    [DataContract]
    public class PayOrderResponse
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PayOrderResponse() {}

        /// <summary>
        /// The date and time when the resource was created, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="create_time", EmitDefaultValue = false)]
        public string CreateTime;

        /// <summary>
        /// The intent.
        /// </summary>
        [DataMember(Name="intent", EmitDefaultValue = false)]
        public string Intent;

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/overview/#hateoas-links).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// The ID of the order.
        /// </summary>
        [DataMember(Name="order_id", EmitDefaultValue = false)]
        public string OrderId;

        /// <summary>
        /// The payer information.
        /// </summary>
        [DataMember(Name="payer_info", EmitDefaultValue = false)]
        public PayerInformation PayerInfo;

        /// <summary>
        /// An array of purchase units. Each unit establishes a contract between a payer and payee.
        /// </summary>
        [DataMember(Name="purchase_units", EmitDefaultValue = false)]
        public List<PurchaseUnit> PurchaseUnits;

        /// <summary>
        /// The status of the order.
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue = false)]
        public string Status;

        /// <summary>
        /// The date and time when the resource was last updated, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="update_time", EmitDefaultValue = false)]
        public string UpdateTime;
    }
}

