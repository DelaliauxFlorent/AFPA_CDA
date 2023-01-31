<?php 
    class ElevesManager{
        public static function Add(Eleves $obj)
        {
            return DAO::Create($obj);
        }
        
        public static function Update(Eleves $obj)
        {
            return DAO::Update($obj);
        }
        
        public static function Delete(Eleves $obj)
        {
            return DAO::Delete($obj);
        }
        
        public static function FindById($id)
        {
            return DAO::Select(Eleves::getChamps(), "Eleves", ["idEleve"=> $id])[0];
        }
        
        public static function GetList(array $nomColonnes = null, array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug =false)
        {
            $nomColonnes = ($nomColonnes==null)?Eleves::getChamps():$nomColonnes;
            return DAO::Select($nomColonnes, "Eleves", $conditions, $orderBy, $limit, $api, $debug);
        }
    }