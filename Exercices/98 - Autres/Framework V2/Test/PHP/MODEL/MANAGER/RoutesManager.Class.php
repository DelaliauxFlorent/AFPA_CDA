<?php 
    class RoutesManager{
        public static function Add(Routes $obj)
        {
            return DAO::Create($obj);
        }
        
        public static function Update(Routes $obj)
        {
            return DAO::Update($obj);
        }
        
        public static function Delete(Routes $obj)
        {
            return DAO::Delete($obj);
        }
        
        public static function FindById($id)
        {
            return DAO::Select(Routes::getChamps(), "Routes", ["idRoute"=> $id]);
        }
        
        public static function GetList(array $nomColonnes = null, array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug =false)
        {
            $nomColonnes = ($nomColonnes==null)?Routes::getChamps():$nomColonnes;
            return DAO::Select($nomColonnes, "Routes", $conditions, $orderBy, $limit, $api, $debug);
        }
    }