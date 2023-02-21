<?php 
    class ArticlesManager{
        public static function Add(Articles $obj)
        {
            return DAO::Add($obj);
        }
        
        public static function Update(Articles $obj)
        {
            return DAO::Update($obj);
        }
        
        public static function Delete(Articles $obj)
        {
            return DAO::Delete($obj);
        }
        
        public static function FindById($id)
        {
            return DAO::Select(Articles::getChamps(), "Articles", ["idArticle"=> $id]);
        }
        
        public static function GetList(array $nomColonnes = null, array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug =false)
        {
            $nomColonnes = ($nomColonnes==null)?Articles::getChamps():$nomColonnes;
            return DAO::Select($nomColonnes, "Articles", $conditions, $orderBy, $limit, $api, $debug);
        }
    }