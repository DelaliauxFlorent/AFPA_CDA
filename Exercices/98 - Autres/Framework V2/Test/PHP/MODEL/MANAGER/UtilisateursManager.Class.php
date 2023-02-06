<?php 
    class UtilisateursManager{
        public static function Add(Utilisateurs $obj)
        {
            return DAO::Create($obj);
        }
        
        public static function Update(Utilisateurs $obj)
        {
            return DAO::Update($obj);
        }
        
        public static function Delete(Utilisateurs $obj)
        {
            return DAO::Delete($obj);
        }
        
        public static function FindById($id)
        {
            return DAO::Select(Utilisateurs::getChamps(), "Utilisateurs", ["idUtilisateur"=> $id]);
        }
        
        public static function GetList(array $nomColonnes = null, array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug =false)
        {
            $nomColonnes = ($nomColonnes==null)?Utilisateurs::getChamps():$nomColonnes;
            return DAO::Select($nomColonnes, "Utilisateurs", $conditions, $orderBy, $limit, $api, $debug);
        }
    }