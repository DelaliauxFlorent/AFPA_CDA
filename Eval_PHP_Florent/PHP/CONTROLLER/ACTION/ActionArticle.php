<?php
$article=new Articles($_POST);
if($article->getIdArticle()!=''){
ArticlesManager::Update($article);
}else{
    ArticlesManager::Add($article);
}
header("location:index.php?page=Liste");