//  Join other side
function joinOtherSide() {
//    var userId = $("#Id").val();
//    if ($("#IsBlocked").val() === "True") {
        $.ajax({
            type: "Post",
            url: "/Person/JoinOtherSide",
            cache: false,
            processData: false,
            contentType: false,
            success: function (result) {
                if (result === "True") {
                    $(".navbar").removeClass("true").addClass("false");
                    $(".icon").removeClass("black").addClass("white");
                    $(".name").text("White Side");
                } else {
                    $(".false").removeClass("false").addClass("true");
                    $(".icon").removeClass("white").addClass("black");
                    $(".name").text("Black Side");
                }
            }
        });

}
