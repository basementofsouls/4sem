<?php

namespace Drupal\news\Controller;

use Drupal\Core\Controller\ControllerBase;

/**
 * Provides route responses for the News module.
 */
class NewsController extends ControllerBase {

  /**
   * Returns a page with the News header.
   *
   * @return array
   *   A simple renderable array.
   */
  public function page() {
    $build = [
      '#markup' => '<h1>News</h1>',
    ];
    return $build;
  }

}