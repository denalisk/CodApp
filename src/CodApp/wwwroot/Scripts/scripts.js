$(document).ready(function() {
  $(".edit-article-button").click(function() {
    var currentArticle = $(this).val();
    var articleDisplayString = "#display-article-" + currentArticle;
    var articleEditString = "#edit-article-" + currentArticle;
    $(articleDisplayString).hide();
    $(articleEditString).show();
  })
})
