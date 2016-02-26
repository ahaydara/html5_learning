/// <reference path="jquery-1.8.2.js" />
$(function () {
    // alert("Hello jQuery");
    // console.log("document.ready called");

    $(".evenRow").css("backgroundColor", "#EEE");

    $("#Username").focus();

    $("#loginButton")
        .click(function () {
            //console.log("clicked");

            var uid = $("#Username");
            var pwd = $("#Password");

            if ($.trim(uid.val()) === "" || $.trim(pwd.val()) === "") {

                $("#errorDialog").show();

                return false;
            }
        });

    $("#closeErrorDialog").click(function () {
        $("#errorDialog").slideUp();
    });

//    $("#loginButton")
//        .click(function () {
//            console.log("clicked");

//            var uid = $("#Username");
//            var pwd = $("#Password");

//            var msg = null;
//            if ($.trim(uid.val()) === "") {
//                msg = "Username is required"
//            }
//            else if ($.trim(pwd.val()) === "") {
//                msg = "Password is required";
//            }
//            if (msg != null) {
//                $("#errorDialog").show();
//                $("#errorMessage").text(msg);
//                return false;
//            }
//        });

    /*
    var div = $("<div>");
    div.css({
    width: "100%",
    height: "100%",
    backgroundColor: "#CCC",
    position: "absolute",
    top: "0px", 
    left: "0px",
    opacity:".5" });
    $("body").append(div);
    div.click(function () {
    div.remove();
    });
    */
});
