$(document).ready(function() {

  //Ajax call to check the reader submission for quality and to see if it is a new reader
  $("#reader-submit-button").click(function() {
    var newReader = {};
    var dataArray = $("#reader-submit").serializeArray();
    var formComplete = true;
    for (let i = 0; i < dataArray.length; i++) {
      newReader[dataArray[i].name] = dataArray[i].value;
      if (dataArray[i].value === "") {
        formComplete = false;
        newReader = null;
        break;
      }
    }
    if (formComplete) {
      $.ajax({
        url: '/Newsletter/CheckReader',
        type: 'POST',
        data: newReader,
        success: function(result) {
          if (result) {
            $(".success").show();
          } else {
            $(".already-added").show();
          }
          $(".reader-form").hide();
        },
        error: function(result) {
          console.log("There was an error");
        }
      })
    } else {
      $(".invalid").show();
    }
  })

  // Ajax call to submit article edits without having to reload the page
  $("#new-edit").submit(function(event) {
    event.preventDefault();
    console.log("Inside the new-edit call");
    var targetArticle = {};
    var dataArray = $(this).serializeArray();
    for (var i = 0; i < dataArray.length; i++) {
      targetArticle[dataArray[i].name] = dataArray[i].value;
    }
    $.ajax({
      url: '/Newsletter/EditArticle',
      type: 'POST',
      data: targetArticle,
      success: function(result) {
        console.log("success!");
      },
      error: function(result, exception) {
        console.log("There was a problem with the request");
        console.log(exception);
      }
    })
  })
})
