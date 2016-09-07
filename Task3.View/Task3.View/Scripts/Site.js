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
                    $(".icon").removeClass("black").addClass("white");
                    $(".name").text("White Side");
                } else {
                    $(".icon").text("Black Side");
                }
            }
        });

}
