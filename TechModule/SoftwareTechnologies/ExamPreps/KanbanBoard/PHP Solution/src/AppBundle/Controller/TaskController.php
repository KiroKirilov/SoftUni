<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Task;
use AppBundle\Form\TaskType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class TaskController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
        $taskRepository = $this
            ->getDoctrine()
            ->getRepository(Task::class);
        $openTasks = $taskRepository->findBy(['status' => 'Open']);
        $inProgressTasks = $taskRepository->findBy(['status' => 'In Progress']);
        $finishedTasks = $taskRepository->findBy(['status' => 'Finished']);
        return $this->render(
            'task/index.html.twig',
            [
                'openTasks' => $openTasks,
                'inProgressTasks' => $inProgressTasks,
                'finishedTasks' => $finishedTasks
            ]
        );
    }

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        $task = new Task();
        $form = $this->createForm(TaskType::class, $task);
        $form->handleRequest($request);
        if ($form->isSubmitted() && $form->isValid()) {
            $em = $this->getDoctrine()->getManager();
            $em->persist($task);
            $em->flush();
            return $this->redirect('/');
        }
        return $this->render(
            'task/create.html.twig',
            ['task' => $task, 'form' => $form->createView()]
        );
    }

    /**
     * @Route("/edit/{id}", name="edit")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function edit($id, Request $request)
    {
        $task = $this
            ->getDoctrine()
            ->getRepository(Task::class)
            ->find($id);
        if ($task == null) {
            return $this->redirect('/');
        }
        $form = $this->createForm(TaskType::class, $task);
        $form->handleRequest($request);
        if ($form->isSubmitted() && $form->isValid()) {
            $em = $this->getDoctrine()->getManager();
            $em->merge($task);
            $em->flush();
            return $this->redirect('/');
        }
        return $this->render('task/edit.html.twig',
            ['task' => $task, 'form' => $form->createView()]);
    }
}
