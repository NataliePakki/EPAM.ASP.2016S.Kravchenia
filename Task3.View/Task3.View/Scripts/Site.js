//  Join other side
function joinOtherSide() {
        $.ajax({
            type: "Post",
            url: "/Person/JoinOtherSide",
            cache: false,
            processData: false,
            contentType: false,
            success: function (result) {
                if (result === "False") {
                    alert("I don't remember what to write this! c:");
                } else {
                    $(".false").removeClass("false").addClass("true");
                    $(".icon").removeClass("white").addClass("black");
                    $(".name").text("Black Side");
                }
            }
        });

}
