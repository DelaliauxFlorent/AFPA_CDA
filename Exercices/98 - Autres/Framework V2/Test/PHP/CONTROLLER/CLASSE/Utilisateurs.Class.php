<?php
class Utilisateurs
{
    ////////////////////////////////////
    // Attributs

    private ?int $_idUtilisateur;
    private ?string $_nomUtilisateur;
    private ?string $_pseudoUtilisateur;
    private ?string $_password;
    private ?string $_mail;
    private ?int $_role;

    ////////////////////////////////////
    #region Accesseurs

    public function getIdUtilisateur()
    {
        return $this->_idUtilisateur;
    }

    public function setIdUtilisateur($idUtilisateur)
    {
        if ($idUtilisateur == "") {
            $this->_idUtilisateur = null;
        } else {
            $this->_idUtilisateur = (int)$idUtilisateur;
        }
    }

    public function getNomUtilisateur()
    {
        return $this->_nomUtilisateur;
    }

    public function setNomUtilisateur(string $nomUtilisateur)
    {
        $this->_nomUtilisateur = $nomUtilisateur;
    }

    public function getPseudoUtilisateur()
    {
        return $this->_pseudoUtilisateur;
    }

    public function setPseudoUtilisateur(string $pseudoUtilisateur)
    {
        $this->_pseudoUtilisateur = $pseudoUtilisateur;
    }

    public function getPassword()
    {
        return $this->_password;
    }

    public function setPassword(string $password)
    {
        $this->_password = $password;
    }

    public function getMail()
    {
        return $this->_mail;
    }

    public function setMail(string $mail)
    {
        $this->_mail = $mail;
    }

    public function getRole()
    {
        return $this->_role;
    }

    public function setRole(int $role)
    {
        $this->_role = $role;
    }

    /**
     * Récupérer la liste des attributs de la classe
     *
     * @return  array  liste des champs
     */
    public static function getChamps()
    {
        $array = get_class_vars(__CLASS__);
        foreach ($array as $key => $value) {
            $listeChamps[] = ltrim($key, "_");
        }
        return $listeChamps;
    }

    #endregion Accesseurs
    ////////////////////////////////////
    // Constructeur

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
    }

    public function hydrate($data)
    {
        foreach ($data as $key => $value) {
            $methode = "set" . ucfirst($key); //ucfirst met la 1ere lettre en majuscule
            if (is_callable(([$this, $methode]))) // is_callable verifie que la methode existe
            {
                $this->$methode($value);
            }
        }
    }
}
