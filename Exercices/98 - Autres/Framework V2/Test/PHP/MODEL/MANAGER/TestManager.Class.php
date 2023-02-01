<?php 
    class TestManager{
        public static function Add(Test $obj)
        {
            return DAO::Create($obj);
        }
        
        public static function Update(Test $obj)
        {
            return DAO::Update($obj);
        }
        
        public static function Delete(Test $obj)
        {
            return DAO::Delete($obj);
        }
        
        public static function FindById($id)
        {
            return DAO::Select(Test::getChamps(), "Test", ["intid"=> $id])[0];
        }
        
        public static function GetList(array $nomColonnes = null, array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug =false)
        {
            $nomColonnes = ($nomColonnes==null)?Test::getChamps():$nomColonnes;
            return DAO::Select($nomColonnes, "Test", $conditions, $orderBy, $limit, $api, $debug);
        }
    }