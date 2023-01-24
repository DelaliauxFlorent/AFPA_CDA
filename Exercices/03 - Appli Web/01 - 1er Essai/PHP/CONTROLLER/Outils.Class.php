<?php
class outils
{
    
    public static function decode($string)
    {
        $encoded=['a', 'b', 'c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A', 'B', 'C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'];
        $decoded=['p', 'v', 'x','s','z','d','f','g','u','h','j','k','l','b','i','o','m','e','q','r','y','c','n','w','t','a','P', 'V', 'X','S','Z','D','F','G','U','H','J','K','L','B','I','O','M','E','Q','R','Y','C','N','W','T','A'];
        foreach ($string as $key => $value) {
            $a=0;
            do {
                if($value==$encoded[$a]){
                    $value=$decoded[$a];
                }
                $a++;
            } while ($a <= 55);
        }
        return $string;
    }
}
