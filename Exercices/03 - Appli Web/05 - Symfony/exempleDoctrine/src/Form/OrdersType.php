<?php

namespace App\Form;

use App\Entity\Orders;
use Symfony\Component\Form\AbstractType;
use Symfony\Component\Form\FormBuilderInterface;
use Symfony\Component\OptionsResolver\OptionsResolver;

class OrdersType extends AbstractType
{
    public function buildForm(FormBuilderInterface $builder, array $options): void
    {
        $builder
            ->add('EmployeeID')
            ->add('OrderDate')
            ->add('RequiredDate')
            ->add('ShippedDate')
            ->add('ShipVia')
            ->add('Freight')
            ->add('ShipName')
            ->add('ShipAddress')
            ->add('ShipCity')
            ->add('ShipRegion')
            ->add('ShipPostalCode')
            ->add('ShipCountry')
            ->add('OrderDetails')
        ;
    }

    public function configureOptions(OptionsResolver $resolver): void
    {
        $resolver->setDefaults([
            'data_class' => Orders::class,
        ]);
    }
}
