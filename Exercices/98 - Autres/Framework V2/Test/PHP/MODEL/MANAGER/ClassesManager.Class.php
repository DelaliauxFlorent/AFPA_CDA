<?php 
    class ClassesManager{
        public static function Add(Classes $obj)
        {
            return DAO::Create($obj);
        }
        
        public static function Update(Classes $obj)
        {
            return DAO::Update($obj);
        }
        
        public static function Delete(Classes $obj)
        {
            return DAO::Delete($obj);
        }
        
        public static function FindById($id)
        {
            return DAO::Select(Classes::getChamps(), "Classes", ["idClasse"=> $id])[0];
        }
        
        public static function GetList(array $nomColonnes = null, array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug =false)
        {
            $nomColonnes = ($nomColonnes==null)?Classes::getChamps():$nomColonnes;
            return DAO::Select($nomColonnes, "Classes", $conditions, $orderBy, $limit, $api, $debug);
        }
    }