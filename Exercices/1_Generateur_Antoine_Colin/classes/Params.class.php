<?php

class Params
{

    /*****************Attributs***************** */

    //Attributs de l'input
    private $_name; // ID de l'input, name de l'input et le for du label
    private $_classInput;
    private $_type="text";
    private $_pattern;
    private $_title;
    private $_required = "true";
    private $_disabled = "";
    private $_hidden = "visible";

    //Texte du Label
    private $_text; //  Placeholder de l'input et text du label
    private $_classLabel;

    private $_classMessage; //attribut de la div Message
    private $_classPicto; //attribut de la div Picto

    /*****************Accesseurs***************** */

    #region
    //////////
    public function getName()
    {
        return $this->_name;
    }

    public function setName($name)
    {
        $this->_name = $name;
    }

    public function getClassInput()
    {
        return $this->_classInput;
    }

    public function setClassInput($classInput)
    {
        $this->_classInput = $classInput;
    }

    public function getType()
    {
        return $this->_type;
    }

    public function setType($type)
    {
        $this->_type = $type;
    }

    public function getPattern()
    {
        return $this->_pattern;
    }

    public function setPattern($pattern)
    {
        $this->_pattern = $pattern;
    }

    public function getTitle()
    {
        return $this->_title;
    }

    public function setTitle($title)
    {
        $this->_title = $title;
    }

    public function getRequired()
    {
        return $this->_required;
    }

    public function setRequired($required)
    {
        $this->_required = $required;
    }

    public function getDisabled()
    {
        return $this->_disabled;
    }

    public function setDisabled($disabled)
    {
        $this->_disabled = $disabled;
    }

    public function getHidden()
    {
        return $this->_hidden;
    }

    public function setHidden($hidden)
    {
        $this->_hidden = $hidden;
    }

    public function getText()
    {
        return $this->_text;
    }

    public function setText($text)
    {
        $this->_text = $text;
    }

    public function getClassLabel()
    {
        return $this->_classLabel;
    }

    public function setClassLabel($classLabel)
    {
        $this->_classLabel = $classLabel;
    }

    public function getClassMessage()
    {
        return $this->_classMessage;
    }

    public function setClassMessage($classMessage)
    {
        $this->_classMessage = $classMessage;
    }

    public function getClassPicto()
    {
        return $this->_classPicto;
    }

    public function setClassPicto($classPicto)
    {
        $this->_classPicto = $classPicto;
    }
    //////////
    #endregion

    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
    }
    public function hydrate($data)
    {
        foreach ($data as $key => $value)
        {
            $methode = "set" . ucfirst($key); //ucfirst met la 1ere lettre en majuscule
            if (is_callable(([$this, $methode]))) // is_callable verifie que la methode existe
            {
                $this->$methode($value);
            }
        }
    }

    /*****************Autres Méthodes***************** */
    
    /**
     * Transforme l'objet en chaine de caractères
     *
     * @return String
     */
    public function __toString()
    {
        return '
        <label 
            for="'.$this->getName().'" 
            class="'.$this->getClassLabel().'">'.$this->getText().'
        </label>'."\n".'
        <input 
        type='.$this->getType().
        ' id="'.$this->getName().
        '" name="'.$this->getName().
        '" placeholder="'.$this->getText().
        '" pattern="'.$this->getPattern().
        '" title="'.$this->getTitle().
        '" class="'.$this->getClassInput().
        '" required='.$this->getRequired().
        ' '.$this->getDisabled().
        ' '.$this->getHidden().'>'."\n".'
        <div class="'.$this->getClassPicto().'"></div>'."\n".'
        <div class="'.$this->getClassMessage().'"></div>'."\n".'
        ';
    }
}


